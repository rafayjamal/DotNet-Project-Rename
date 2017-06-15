using System.IO;
using System.Threading.Tasks;
using RenCs.Utlity;

namespace RenCs.Core
{
    class RenFolder
    {
        public static void RenameFolderName(string folderPath, string oldName, string newName)
        {
            Directory.Move(folderPath, CommonFunction.ReplaceLastOccurrence(folderPath, oldName, newName));
        }


        public static void ParallelRenameFodlder(string[] allSourceFolders, string oldName, string newName)
        {
            if (allSourceFolders.Length > 0)
            {
                Parallel.ForEach(allSourceFolders, item =>
                {
                    RenameFolderName(item, oldName, newName);
                });
            }
        }

    }
}
