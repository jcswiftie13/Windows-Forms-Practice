using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}


namespace log_parsing
{
    class ReadFile
    {
        private string location;
        public ReadFile(string path)
        {
            location = path;
        }
        public Tuple<string, string> rettime()
        {
            string[] lines = System.IO.File.ReadAllLines($"{location}");
            string start=null, end=null;
            int count = 0;
            int num_log = lines.Length;
            foreach (string line in lines)
            {
                string[] parser = line.Split(',');
                if (count == 0)
                {
                    start = parser[2];
                }
                if (count == (num_log - 1))
                {
                    end = parser[2];
                }
                count += 1;
            }
            var tuple = new Tuple<string, string>(start, end);
            return tuple;
        }
        public Dictionary<string, int> retlevel()
        {
            Dictionary<string, int> levels = new Dictionary<string, int>()
            {
                {"DEBUG", 0 }, {"INFO", 0}, {"WARNING", 0}, { "ERROR", 0}
            };
            string[] lines = System.IO.File.ReadAllLines($"{location}");
            foreach (string line in lines)
            {
                string[] parser = line.Split(',');
                foreach (var key in levels.Keys.ToList())
                {
                    if (key == parser[0])
                    {
                        int cur_value = Convert.ToInt32(levels[key]);
                        levels[key] = cur_value + 1;
                    }
                }
            }
            return levels;
        }
        public Dictionary<string, int> retcategory()
        {
            Dictionary<string, int> categories = new Dictionary<string, int>();
            string[] lines = System.IO.File.ReadAllLines($"{location}");
            foreach (string line in lines)
            {
                bool exist = false;
                string[] parser = line.Split(',');
                foreach (var key in categories.Keys.ToList())
                {
                    if (key == parser[1])
                    {
                        int cur_value = Convert.ToInt32(categories[key]);
                        categories[key] = cur_value + 1;
                        exist = true;
                        continue;
                    }
                }
                if (exist == false)
                {
                    categories.Add(parser[1], 0);
                }
            }
            return categories;
        }
        public Dictionary<string, int> rettag()
        {
            Dictionary<string, int> Tag_dic = new Dictionary<string, int>();
            Regex rx = new Regex(@"(?<=@)\w+");
            string[] lines = System.IO.File.ReadAllLines($"{location}");
            foreach (string line in lines)
            {
                foreach (Match match in rx.Matches(line))
                {
                    string Tag_temp = match.ToString();
                    string[] Tags = Tag_temp.Split(';');
                    foreach (string Tag in Tags)
                    {
                        bool exist = false;

                        foreach (var key in Tag_dic.Keys.ToList())
                        {
                            if (key == Tag)
                            {
                                int cur_value = Convert.ToInt32(Tag_dic[key]);
                                Tag_dic[key] = cur_value + 1;
                                exist = true;
                                continue;
                            }
                        }
                        if (exist == false)
                        {
                            Tag_dic.Add(Tag, 0);
                        }
                    }
                }
            }
            return Tag_dic;
        }
    }
}