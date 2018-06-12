using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DStopWatch
{
    /// <summary>
    /// Wrapper for stop watch for use only in debug mode,
    /// and removing from compiled release.
    /// </summary>
    public class DStopWatch
    {
       

        /// <summary>
        /// Diagnostics stopwatch instance used internal to class.
        /// </summary>
        private System.Diagnostics.Stopwatch _stopWatch;
        private System.Diagnostics.Stopwatch StopWatch {
            get {
                Debug.WriteLine("Init Stopwatch");
                if (_stopWatch == null)
                    _stopWatch = new System.Diagnostics.Stopwatch();
                
                return _stopWatch;
            }
        }
        
        /// <summary>
        /// Start the Debug Stopwatch
        /// </summary>
        [Conditional("DEBUG")]
        public void Start()
        {
            Debug.WriteLine("Start Stopwatch");
            StopWatch.Start();
        }

        /// <summary>
        /// Stop the Debug Stopwatch
        /// </summary>
        [Conditional("DEBUG")]
        public void Stop()
        {
            Debug.WriteLine("Stop Stopwatch");
            StopWatch.Stop();
            Elapsed = _stopWatch.Elapsed;
        }

        /// <summary>
        /// Return the elapsed time as a timespan
        /// </summary>
        public TimeSpan Elapsed { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            //create stopwatch
            Stopwatch sw = new Stopwatch();

            //start stopwatch
            sw.Start();

            //pause
            Thread.Sleep(5000);

            //stop stopwatch
            sw.Stop();

            //report results in ms
            Debug.WriteLine("Execution completed in {0} ms.", sw.Elapsed.TotalMilliseconds);


            DStopWatch dsw = new DStopWatch();
            dsw.Start();
            Thread.Sleep(5000);
            dsw.Stop();

            Debug.WriteLine("Execution completed in {0} ms.", dsw.Elapsed.TotalMilliseconds);
            Console.WriteLine("Program Completed.");
            Console.ReadKey();

        }



    }
}
