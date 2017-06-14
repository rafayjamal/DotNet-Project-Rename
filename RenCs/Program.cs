using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RenCs
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = System.Configuration.ConfigurationManager.AppSettings.Get("source");
            var oldProjectName = System.Configuration.ConfigurationManager.AppSettings.Get("oldProjectName");
            var newProjectName = System.Configuration.ConfigurationManager.AppSettings.Get("newProjectName");
            var oldProjectNamePattern = oldProjectName + "*";
            var newProjectNamePattern = newProjectName + "*";


            var allSourceFolders = Directory.GetDirectories(source, oldProjectNamePattern, SearchOption.AllDirectories);
            Console.WriteLine("Renaming folder.");
            if (allSourceFolders.Length > 0)
            {
                foreach (var item in allSourceFolders)
                {
                    Directory.Move(item, ReplaceLastOccurrence(item, oldProjectName, newProjectName));
                }
            }

            Console.WriteLine("Renaming cs file.");
            var allCSFiles = Directory.GetFiles(source, "*.cs", SearchOption.AllDirectories);
            foreach (var item in allCSFiles)
            {
                File.WriteAllText(item, Regex.Replace(File.ReadAllText(item), "namespace " + oldProjectNamePattern, "namespace ABC"));
                File.WriteAllText(item, Regex.Replace(File.ReadAllText(item), "using " + oldProjectNamePattern, "using ABC"));
            }

            Console.WriteLine("Assembly info file.");
            var allAssemblyInfoFiles = Directory.GetFiles(source, "AssemblyInfo.cs", SearchOption.AllDirectories);
            foreach (var item in allAssemblyInfoFiles)
            {
                File.WriteAllText(item, Regex.Replace(File.ReadAllText(item), oldProjectNamePattern, newProjectName));
            }

            var allSourceFiles = Directory.GetFiles(source, oldProjectNamePattern, SearchOption.AllDirectories);
            if (allSourceFiles.Length > 0)
            {
                foreach (var item in allSourceFiles)
                {
                    File.WriteAllText(item, Regex.Replace(File.ReadAllText(item), oldProjectNamePattern, newProjectName));
                    File.Move(item, ReplaceLastOccurrence(item, oldProjectName, newProjectName));
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
