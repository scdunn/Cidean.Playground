using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSVImport
{
    class Program
    {
        static void Main(string[] args)
        {

            var statesDictionary = CSVToDictionary(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "states.csv"));

            foreach (var state in statesDictionary)
                Console.WriteLine("Abbrev={0} Name={1}", state.Key, state.Value);


            var statesList = CSVToList(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "states.csv"));

            foreach (var state in statesList)
                Console.WriteLine("Abbrev={0} Name={1}", state.Abbrev, state.Name);

            Console.ReadKey();
        }

        static Dictionary<string,string> CSVToDictionary(string path)
        {
            var data = System.IO.File.ReadAllLines(path);
            return data.Skip(1).Select(m => m.Split(",")).ToDictionary(m=>m[1],m=>m[0]);
        }

        static IList<State> CSVToList(string path)
        {
            var data = System.IO.File.ReadAllLines(path);
            return data.Skip(1).Select(m => m.Split(",")).Select(m => new State() { Abbrev = m[0], Name = m[1] }).ToList<State>();
        }

        

    }

    class State
    {
        public string Abbrev { get; set; }
        public string Name { get; set; }
        
    }
}
