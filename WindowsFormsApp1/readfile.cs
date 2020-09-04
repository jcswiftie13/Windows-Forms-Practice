using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace log_parsing
{
    class ReadFile
    {
        private string location;
        public ReadFile(string path)
        {
            location = path;
        }
        public void rettime()
        {
            string[] lines = System.IO.File.ReadAllLines($"{location}");
            int count = 0;
            int num_log = lines.Length;
            foreach (string line in lines)
            {
                string[] parser = line.Split(",");
                if (count == 0)
                {
                    Console.WriteLine($"Starts at: {parser[2]}");
                }
                if (count == (num_log - 1))
                {
                    Console.WriteLine($"Ends at: {parser[2]}");
                }
                count += 1;
            }
        }
        public void retlevel()
        {
            Dictionary<string, int> levels = new Dictionary<string, int>()
            {
                {"DEBUG", 0 }, {"INFO", 0}, {"WARNING", 0}, { "ERROR", 0}
            };
            string[] lines = System.IO.File.ReadAllLines($"{location}");
            foreach (string line in lines)
            {
                string[] parser = line.Split(",");
                foreach (var key in levels.Keys.ToList())
                {
                    if (key == parser[0])
                    {
                        int cur_value = Convert.ToInt32(levels[key]);
                        levels[key] = cur_value + 1;
                    }
                }
            }
            Console.WriteLine($"DEBUG: {levels["DEBUG"]}, INFO: {levels["INFO"]}, WARNING: {levels["WARNING"]}, ERROR: {levels["ERROR"]}");
        }
        public void retcategory()
        {
            Dictionary<string, int> levels = new Dictionary<string, int>();
            string[] lines = System.IO.File.ReadAllLines($"{location}");
            foreach (string line in lines)
            {
                bool exist = false;
                string[] parser = line.Split(",");
                foreach (var key in levels.Keys.ToList())
                {
                    if (key == parser[1])
                    {
                        int cur_value = Convert.ToInt32(levels[key]);
                        levels[key] = cur_value + 1;
                        exist = true;
                        continue;
                    }
                }
                if (exist == false)
                {
                    levels.Add(parser[1], 0);
                }
            }
            foreach (KeyValuePair<string, int> kvp in levels)
            {
                Console.Write(kvp.Key + ": " + kvp.Value + "\t");
            }
        }
    }
    class process
    {
        static void Main()
        {
            string location;
            Console.Write("Input file path: ");
            location = Console.ReadLine();
            ReadFile reader = new ReadFile(location);
            reader.retlevel();
            reader.retcategory();
            reader.rettime();
        }
    }
}