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
            return File.ReadAllText(path);
        }
    }
}
