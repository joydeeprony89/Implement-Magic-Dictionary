using System;
using System.Collections.Generic;

namespace Implement_Magic_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MagicDictionary magic = new MagicDictionary();
            var dict = new string[] { "hello","leetcode" };
            magic.BuildDict(dict);
            Console.WriteLine(magic.Search("hell"));
            Console.WriteLine(magic.Search("hello"));
            Console.WriteLine(magic.Search("hallo"));
            Console.WriteLine(magic.Search("leetcoded"));
        }
    }

    public class MagicDictionary
    {
        Dictionary<int, List<string>> kvp;
        public MagicDictionary()
        {
            kvp = new Dictionary<int, List<string>>();
        }

        public void BuildDict(string[] dictionary)
        {
            foreach(string str in dictionary)
            {
                int length = str.Length;
                if (!kvp.ContainsKey(length))
                {
                    kvp.Add(length, new List<string> { str });
                }
                else
                {
                    var existingValues = kvp[length];
                    existingValues.Add(str);
                    kvp[length] = existingValues;
                }
            }
        }

        public bool Search(string searchWord)
        {
            if (!kvp.ContainsKey(searchWord.Length)) return false;

            var getValues = kvp[searchWord.Length];
            foreach(string str in getValues)
            {
                int count = 0;
                for (int i =0; i < searchWord.Length; i++)
                {
                    if (str[i] != searchWord[i])
                    {
                        count++;
                    }

                    if (count > 1) break;
                }

                if (count == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
