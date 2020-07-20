﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO.Ports;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading;
using System.Globalization;
using System.Windows.Input;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Text;
using System.Windows.Forms;

namespace AnimatronicMouthGUI
{
    public class RunLogic
    {
        private VirtualFaceController VirtualFace;
        private  Random random; 
        private  FaceController faceController;
        private  Mouth m;
        private EyeController eyeController;
        private ReaderWriterLockSlim mouthlock = new ReaderWriterLockSlim();
        private ReaderWriterLockSlim eyelock = new ReaderWriterLockSlim();
        private int[][] Eyes = new int[2][];
        private string PortQueue = "0";
        private ManualResetEvent ResetEvent;
        private reader reader;
        private OWMForecast oWMForecast;
        private NewsApiTop NewsAPI;
        private OWMCurrent oWM;
        private Interpreter interpreter;
        private string[] keys;
        
        public RunLogic(VirtualFaceController vface)
        {
            VirtualFace = vface;
        }

        public void Setup()
        {
            ResetEvent = new ManualResetEvent(true);
            random = new Random();
            faceController = new FaceController("COM11", 115200);
            m = new Mouth("Microsoft David Desktop");
            eyeController = new EyeController();
            reader = new reader();
            interpreter = new Interpreter();

            keys = reader.ReadKeys();
            oWM = new OWMCurrent(keys[1]);
            oWMForecast = new OWMForecast(keys[1]);
            NewsAPI = new NewsApiTop(keys[0]);


            ThreadStart eyethread = new ThreadStart(processEyes);
            ThreadStart portwriter = new ThreadStart(writeData);
            //ThreadStart main = new ThreadStart(MainLoop);
            Eyes = eyeController.Eyes;
            m.MouthPosChanged += mouthEventHandler;
            eyeController.EyesChanged += writeEyevals;
            faceController.POST();

            // start them  
            
            Thread writerThread = new Thread(portwriter);
            //Thread interfaceThread = new Thread(main);
            Thread Eyethread = new Thread(eyethread);
            writerThread.Start();
            Thread.Sleep(3000);
            //interfaceThread.Start();
            Eyethread.Start();
            
        }

        
        public void fullUpdate()
        {
            WeatherUpdate();
            NewsUpdate();
        }

        public void WeatherUpdate()
        {
            speakWeather(m, interpreter, oWMForecast, oWM);
        }

        public void NewsUpdate()
        {
            speakNews(m, interpreter, NewsAPI);
        }

        private void speakNews(Mouth mouth, Interpreter interpreter, NewsApiTop newsAPI)
        {
            TopNews data = newsAPI.GetTopNews("gb");
            mouth.speakMsg(string.Format("The top 5 news stories today are:"));
            foreach (string story in interpreter.Top5(data))
            {
                mouth.speakMsg(string.Format(story));
            }
        }

        private void speakWeather (Mouth mouth, Interpreter interpreter, OWMForecast oWMForecast, OWMCurrent oWM)
        {          
            
            try
            {
                //var returned = oWM.GetCurrent("cv5", "GB", "Coventry", 1);
                ForecastData fc = oWMForecast.ForeCastWeahterData("cvk.jk5", "GB", "Covry", 2);
                var returned = oWM.GetCurrent("cv5", "GB", "Coventry", 2);
                mouth.speakMsg(string.Format(interpreter.CurrentSummary(returned)));
                mouth.speakMsg(interpreter.ForecastSummary(fc));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         
        }

        protected void processEyes()
        {

            
            while (true)
            {
                ResetEvent.WaitOne(); // allows the thread to be paused by chnge colour func
                eyeController.blink();
                if(random.Next(5) == 2)
                {
                    eyeController.blink();
                    if(random.Next(10) == 10)
                    {
                        eyeController.blink();
                    }
                }
                Thread.Sleep(random.Next(5000));
                Thread.Sleep(1000);
                //eyeController.disco();
            }
        }

        protected void writeData()
        {
            while (true)
            {
                eyelock.EnterReadLock();
                mouthlock.EnterReadLock();
                try
                {
                    
                    bool physical = faceController.writeFace(PortQueue, Eyes);
                    if (physical)
                    {
                        VirtualFace.writeFace(PortQueue, Eyes);

                    }
                }
                finally
                {
                    eyelock.ExitReadLock();
                    mouthlock.ExitReadLock();
                    Thread.Sleep(5);
                }
                
            }
        }

        public void ChangeColour(int[] colour)
        {
            ResetEvent.Reset();
            eyeController.setBoth(colour);
            ResetEvent.Set();
        }

        public void mouthEventHandler(object sender, MouthPosChangedEventArgs e)
        {
            mouthlock.EnterWriteLock();
            try
            {
                
                PortQueue = e.Pos;
            }
            finally
            {
                mouthlock.ExitWriteLock();
            }
            
        }

        public void writeEyevals(object sender, EyesChangedEventArgs e)
        {
            eyelock.EnterWriteLock();
            try
            {
                Eyes = e.Eyes;

            }
            catch
            {
                Console.WriteLine("Escaped");
            }
            finally
            {
                
                eyelock.ExitWriteLock();
            }

        }

        

    }
}
//TODO: Comment Code properly