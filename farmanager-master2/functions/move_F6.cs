using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace farmanager.functions
{
    class move_F6
    {
        public void move_file(string filepath,string where_to_move_path)
        {
            /**
            if (File.Exists(filepath))
            {
                Console.WriteLine("moving          " + filepath);
                try
                {
                    File.Move(filepath,where_to_move_path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            **/
            FileAttributes attr = File.GetAttributes(filepath);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                if (Directory.Exists(filepath))
                {
                    Console.WriteLine("moving   dir       " + filepath);
                    try
                    {
                        Directory.Move(filepath, where_to_move_path);
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
                    Console.WriteLine("moving   file       " + filepath);
                    try
                    {
                        File.Move(filepath, where_to_move_path);
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

