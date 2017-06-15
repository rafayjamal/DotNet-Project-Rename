using System.IO;
using System.Threading.Tasks;
using RenCs.Utlity;

namespace RenCs.Core
{
    class RenFile
    {
        public static void RenameFile(string file, string oldName, string newName)
        {
            if (File.Exists(CommonFunction.ReplaceLastOccurrence(file,oldName,newName)))
            {
                File.Delete(CommonFunction.ReplaceLastOccurrence(file,oldName,newName));
            }
            File.Move(file, CommonFunction.ReplaceLastOccurrence(file, oldName, newName));
        }


        public static void ParallelRenameFile(string[] allSourceFiles, string oldName, string newName)
        {
            if (allSourceFiles.Length > 0)
            {
                Parallel.ForEach(allSourceFiles, item =>
                {
                    RenameFile(item, oldName, newName);
                });
            }
        }

    }
}
