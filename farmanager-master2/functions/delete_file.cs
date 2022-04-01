using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farmanager.functions
{
    class delete_file
    {
        public void delete_file_by_filepath(string filepath)
        {
            FileAttributes attr = File.GetAttributes(filepath);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                if (Directory.Exists(filepath))
                {
                    Console.WriteLine("deleting   dir       " + filepath);
                    try
                    {
                        Directory.Delete(filepath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else 
            {
                if (File.Exists(filepath))
                {
                    Console.WriteLine("deleting   file       " + filepath);
                    try
                    {
                        File.Delete(filepath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

              
        }

    }
}
