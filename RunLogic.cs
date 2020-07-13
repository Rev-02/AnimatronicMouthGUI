using System;
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

        protected void MainLoop()
        {
            
            reader keyreader = new reader();
            string[] keys = keyreader.ReadKeys();
            
            NewsApiTop newsAPI = new NewsApiTop(keys[0]);
            OWMForecast oWMForecast = new OWMForecast(keys[1]);
            OWMCurrent oWM = new OWMCurrent(keys[1]);
            Interpreter interpreter = new Interpreter();
            
            while (true)
            {
                string intext = "";
                Console.Write("Press 1 for Full Update, 2 for news, 3 for weather \t");
                intext = Console.ReadLine();
                switch (intext)
                {
                    default:
                        break;
                    case "1":
                        speakNews(m, interpreter, newsAPI);
                        speakWeather(m, interpreter, oWMForecast, oWM);
                        break;
                    case "2":
                        speakNews(m, interpreter, newsAPI);

                        break;
                    case "3":

                        speakWeather(m, interpreter, oWMForecast, oWM);
                        break;

                }
            }
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
            
            ForecastData fc = oWMForecast.ForeCastWeahterData("cv5", "GB", "Coventry", 1);
            
            
            try
            {
                //var returned = oWM.GetCurrent("cv5", "GB", "Coventry", 1);
                var returned = oWM.GetCurrent("cv5", "GB", "Coventry", 2);
                mouth.speakMsg(string.Format(interpreter.CurrentSummary(returned)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            mouth.speakMsg(interpreter.ForecastSummary(fc));
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
                        Console.WriteLine("write virtual");
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
//TODO: Remove bad Comments
//TODO: Comment Code properly