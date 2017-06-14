using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenCs.Utlity;

namespace RenCs.Core
{
    class RenFolder
    {
        static public void RenameFolderName(string folderPath, string oldName, string newName)
        {
            Directory.Move(folderPath, CommonFunction.ReplaceLastOccurrence(folderPath, oldName, newName));
        }


        static public void ParallelRenameFodlder(string[] allSourceFolders, string oldName, string newName)
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
