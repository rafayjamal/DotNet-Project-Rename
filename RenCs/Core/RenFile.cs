using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RenCs.Utlity;

namespace RenCs.Core
{
    class RenFile
    {
        static public void RenameFile(string file, string oldName, string newName)
        {
            Directory.Move(file, CommonFunction.ReplaceLastOccurrence(file, oldName, newName));
        }


        static public void ParallelRenameFile(string[] allSourceFiles, string oldName, string newName)
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
