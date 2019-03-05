using System;
using System.Runtime.InteropServices;


namespace CoreOSPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            if (CurrentOS.ISOSLinux())
                Console.WriteLine("OS is Linux");
            else if (CurrentOS.IsOSWindows())
                Console.WriteLine("OS is Windows");
            else if (CurrentOS.ISOSLinux())
                Console.WriteLine("OS is OSX");

            Console.ReadKey();
        }
    }

    public static class CurrentOS
    {
        public static bool IsOSWindows () => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool ISOSLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public static bool IsOSOSX() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

    }
}
