using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancelTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //task will run until spacebar pressed.
            Console.WriteLine("Press spacebar to cancel task.");

            //create a cancellation token source and set token so task
            //can be cancelled.
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            
            //execute asyncronous task passing in cancel token.
            Task.Run(() =>
            {
                //continue executing task until token is set to cancelled.
                while (!token.IsCancellationRequested)
                {
                    Console.WriteLine("Doing Something...");
                    Thread.Sleep(2500);
                }

            }, token);
            

            //loop until spacebar pressed.
            while(true)
            {   
                //check if keypress is available on input stream
                if(Console.KeyAvailable)
                {
                    //check if key press was spacebar
                    Console.WriteLine("Checking if keypress was spacebar.");
                    if(Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    {
                        //set cancellation token to cancel
                        Console.WriteLine("Task Canceled.");
                        cts.Cancel();
                        break;
                    }
                }
            }

            //finish off the app console
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
