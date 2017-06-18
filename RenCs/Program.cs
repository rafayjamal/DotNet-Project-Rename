using RenCs.Core;
using System;
using System.IO;

namespace RenCs
{
    class Program
    {
        static void Main()
        {
            var source = System.Configuration.ConfigurationManager.AppSettings.Get("source");
            var oldProjectName = System.Configuration.ConfigurationManager.AppSettings.Get("oldProjectName");
            var newProjectName = System.Configuration.ConfigurationManager.AppSettings.Get("newProjectName");
            var oldProjectNamePattern = oldProjectName + "*";

            var allTopSourceFolders = Directory.GetDirectories(source, oldProjectNamePattern, SearchOption.TopDirectoryOnly);
            Console.WriteLine("Renaming folder.");
            RenFolder.ParallelRenameFodlder(allTopSourceFolders, oldProjectName, newProjectName);

            var allSourceFolders = Directory.GetDirectories(source, oldProjectNamePattern, SearchOption.AllDirectories);
            Console.WriteLine("Renaming folder.");
            RenFolder.ParallelRenameFodlder(allSourceFolders, oldProjectName, newProjectName);

            Console.WriteLine("Renaming content in cs file.");
            var allCsFiles = Directory.GetFiles(source, "*.cs", SearchOption.AllDirectories);
            RenContent.ParallelReplaceContent(allCsFiles, "namespace " + oldProjectName, "namespace " + newProjectName);
            RenContent.ParallelReplaceContent(allCsFiles, "using " + oldProjectName, "using " + newProjectName);

            Console.WriteLine("Renaming content in assembly info file.");
            var allAssemblyInfoFiles = Directory.GetFiles(source, "AssemblyInfo.cs", SearchOption.AllDirectories);
            RenContent.ParallelReplaceContent(allAssemblyInfoFiles, oldProjectName, newProjectName);

            Console.WriteLine("Renaming content in csproj file.");
            var allCsProjFiles = Directory.GetFiles(source, "*.csproj", SearchOption.AllDirectories);
            RenContent.ParallelReplaceContent(allCsProjFiles, oldProjectName, newProjectName);

            Console.WriteLine("Renaming content in sln file.");
            var allSlnFiles = Directory.GetFiles(source, "*.sln", SearchOption.AllDirectories);
            RenContent.ParallelReplaceContent(allSlnFiles, oldProjectName, newProjectName);

            Console.WriteLine("Renaming content in Global.asax file.");
            var allGasaxFiles = Directory.GetFiles(source, "Global.asax", SearchOption.AllDirectories);
            RenContent.ParallelReplaceContent(allGasaxFiles, oldProjectName, newProjectName);

            Console.WriteLine("Renaming content in applicationhost.config file.");
            var allApplHostConfigFiles = Directory.GetFiles(source, "applicationhost.config", SearchOption.AllDirectories);
            RenContent.ParallelReplaceContent(allApplHostConfigFiles, oldProjectName, newProjectName);

            Console.WriteLine("Renaming files.");
            var allSourceFiles = Directory.GetFiles(source, oldProjectNamePattern, SearchOption.AllDirectories);
            RenFile.ParallelRenameFile(allSourceFiles, oldProjectName, newProjectName);
        }
    }
}
