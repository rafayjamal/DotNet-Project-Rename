using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RenCs.Core
{
    class RenContent
    {
        public static void ReplaceContent(string file, string pattern, string replace)
        {
            File.WriteAllText(file, Regex.Replace(File.ReadAllText(file), pattern, replace));
        }

        public static void ParallelReplaceContent(string[] files, string pattern, string replace)
        {
            if (files.Length > 0)
            {
                Parallel.ForEach(files, item =>
                {
                    ReplaceContent(item, pattern, replace);
                });
            }
        }
    }
}
