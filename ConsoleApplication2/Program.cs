using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = @"F:\ngNetPowerStarter\src\PowerStarter\";
            var allSourceFolders = Directory.GetDirectories(source, "PowerStarter*", SearchOption.AllDirectories);
            if (allSourceFolders.Length > 0)
            {
                foreach (var item in allSourceFolders)
                {
                    Directory.Move(item, ReplaceLastOccurrence(item, "PowerStarter", "ABC"));
                }
            }

            var allCSFiles = Directory.GetFiles(source, "*.cs", SearchOption.AllDirectories);
            foreach (var item in allCSFiles)
            {
                File.WriteAllText(item, Regex.Replace(File.ReadAllText(item), "namespace PowerStarter*", "namespace ABC"));
                File.WriteAllText(item, Regex.Replace(File.ReadAllText(item), "using PowerStarter*", "using ABC"));
            }

            var allSourceFiles = Directory.GetFiles(source, "PowerStarter*", SearchOption.AllDirectories);
            if (allSourceFiles.Length > 0)
            {
                foreach (var item in allSourceFiles)
                {
                    File.ReadAllText(item).Replace("PowerStarter", "ABC");
                    File.WriteAllText(item, Regex.Replace(File.ReadAllText(item), "PowerStarter*", "ABC"));
                    File.Move(item, ReplaceLastOccurrence(item, "PowerStarter", "ABC"));
                }
            }


        }

        public static string ReplaceLastOccurrence(string Source, string Find, string Replace)
        {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }
    }
}
