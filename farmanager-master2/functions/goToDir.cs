using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmanager.functions
{
    class goToDir
    {

        private static readonly Path path = new Path();
        private bool IsFolder(string path)
        {
            return ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory);
        }


        public void openDir(string _path, TextBox box, ListView listView, bool up) {

            Console.WriteLine(_path);

            if (IsFolder(_path))
            {
                if (up) _path += @"\";
                path.changePathTopTextBox(box, _path, listView);
            }
            else 
            {
                var proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = _path;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
        }
    }
}
