using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blair.Compiler.Util
{
    public class Files
    {
        public static string Read(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch
            {
                return string.Empty;
            }
        }

        public static bool Write(string path, string content = "")
        {
            try
            {
                File.WriteAllText(path, content);
                return true;
            }
            catch
            {
                return false;
            }            
        }
    }
}
