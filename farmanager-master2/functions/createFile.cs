using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmanager.functions
{
    class createFile
    {

        public void createNewFile(string _path, string _name) {
            if (_name.Contains('.')) { FileStream fs = File.Create(_path + _name);
                fs.Close();
            }
            else { DirectoryInfo di = Directory.CreateDirectory(_path + _name); }
        }

    }
}
