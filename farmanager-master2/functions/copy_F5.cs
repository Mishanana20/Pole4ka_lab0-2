using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace farmanager.functions
{
    class copy_F5
    {
        public void copy_file(string fileName, string sourcePath, string targetPath) 
        {
            bool copySubDirs = true;
            string filepath = System.IO.Path.Combine(sourcePath , fileName);
            targetPath = System.IO.Path.Combine(targetPath, fileName);
            FileAttributes attr = File.GetAttributes(filepath);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                if (Directory.Exists(filepath))
                {
                    Console.WriteLine("moving   dir       " + filepath);
                    try
                    {

                        DirectoryCopy(filepath,targetPath,true);
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
                        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.Directory.CreateDirectory(targetPath);
                        System.IO.File.Copy(sourceFile, destFile, true);
                        if (System.IO.Directory.Exists(sourcePath))
                        {
                            string[] files = System.IO.Directory.GetFiles(sourcePath);
                            foreach (string s in files)
                            {
                                fileName = System.IO.Path.GetFileName(s);
                                destFile = System.IO.Path.Combine(targetPath, fileName);
                                System.IO.File.Copy(s, destFile, true);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Такого пути нет, пашол атсюда!!11");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        public void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(System.IO.Path.Combine(destDirName));

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = System.IO.Path.Combine(destDirName , file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    //string tempPath = destDirName + subdir.Name;
                    string tempPath = System.IO.Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
    }

}


