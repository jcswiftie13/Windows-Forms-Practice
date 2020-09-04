using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace log_parsing
{
    class FileReader
    {
        private int count = 0;
        private int num_log = 0;
        private string[] lines;
        private string start = null, end = null;
        private Dictionary<string, int> Levels = new Dictionary<string, int>()
        {
            {"DEBUG", 0 }, {"INFO", 0}, {"WARNING", 0}, { "ERROR", 0}
        };
        private Dictionary<string, int> Categories = new Dictionary<string, int>();
        private Dictionary<string, int> Tag_dic = new Dictionary<string, int>();
        
        private void SetPath(string path)
        {
            lines = System.IO.File.ReadAllLines($"{path}");
            num_log = lines.Length;
        }
        
        public FileReader(string path)
        {
            SetPath(path);
            foreach (string line in lines)
            {
                string[] parser = line.Split(',');
                if(count == 0)
                {
                    start = parser[2];
                }
                else if (count == (num_log - 1))
                {
                    end = parser[2];
                }
                UpdateLevel(parser);
                UpdateCategory(parser);
                UpdateTag(parser);
                count += 1;
            }
        }
        
        public Tuple<string, string> PassTime()
        {
            var tuple = new Tuple<string, string>(start, end);
            return tuple;
        }
        
        public Dictionary<string, int> PassLevel()
        {
            return Levels;
        }
        
        public Dictionary<string, int> PassCategory()
        {
            return Categories;
        }
        
        public Dictionary<string, int> PassTag()
        {
            return Tag_dic;
        }
        
        private void UpdateLevel(string[] parser)
        {
            if (Levels.ContainsKey(parser[0]))
            {
                int cur_value = Convert.ToInt32(Levels[parser[0]]);
                Levels[parser[0]] = cur_value + 1;
            }
        }
        
        private void UpdateCategory(string[] parser)
        {
            bool exist = false;
            if (Categories.ContainsKey(parser[1]))
            {
                int cur_value = Convert.ToInt32(Categories[parser[1]]);
                Categories[parser[1]] = cur_value + 1;
                exist = true;
            }
            if (!exist)
            {
                Categories.Add(parser[1], 1);
            }
        }
        
        private void UpdateTag(string[] parser)
        {
            string temp = parser[3];
            int pos_start = temp.IndexOf('@');
            int pos_end = temp.IndexOf('#');
            string extract = null;
            string[] tags = null;
            if (pos_start >= 0 && pos_end >=0)
            {
                extract = temp.Remove(pos_end);
                extract = extract.Remove(0, 1);
                tags = extract.Split(';');
                foreach (string tag in tags)
                {
                    if (Tag_dic.ContainsKey(tag))
                    {
                        int cur_value = Convert.ToInt32(Tag_dic[tag]);
                        Tag_dic[tag] = cur_value + 1;
                    }
                    else
                    {
                        Tag_dic.Add(tag, 1);
                    }
                }
            }
        }
    }
}