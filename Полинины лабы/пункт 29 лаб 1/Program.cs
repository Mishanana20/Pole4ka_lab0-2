using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKdir__p
{
    class Program
    {
        static int Main(string[] args)
        {

            bool isKeyB=false;
            bool isKeyS=false;
            string sKeyWords;
            List<string> files = new List<string>(); //список, содаржащий несколько файлов


            ///
            /// --help
            ///
            if (args.Length == 1) //если есть только один аргумент, то вывод команды HELP или INFO из файлы
            {
                if (args[0] == "--help")
                {
                    StreamReader sr = new StreamReader("help.txt");

                    string s;

                    while (sr.EndOfStream != true)
                    {
                        s = sr.ReadLine();

                        Console.WriteLine(s);
                    }

                    sr.Close();
                    return 0;
                }
                if (args[0] == "--info")
                {
                    StreamReader sr = new StreamReader("info.txt");

                    string s;

                    while (sr.EndOfStream != true)
                    {
                        s = sr.ReadLine();

                        Console.WriteLine(s);
                    }

                    sr.Close();
                    return 0;
                }
                else
                {

                }
            }


           
            ///
            /// если аргументов больше
            /// Ввод начинается с команды tac
            ///

            if (args.Length > 1) //аргументов больше
            {
                if (args[0] == "tac") //первый аргумент должен быть нашей командой
                {
                    for (int i = 1; i < args.Length; i++)
                    {
                        if (args[i] == "-b") //если аргумент -b 
                        {
                            isKeyB = true;
                        }
                        if (args[i] == "-s") //если аргумент -s 
                        {
                            isKeyS = true;
                            sKeyWords = args[i + 1].Replace("\"", ""); //то следующий аргумент является разделителем строки. Удаляем из строки ковычки
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Команда не найдена");
                }
            }
            foreach (string arg in args) //проходимся по всем аргументам
            {
                if (arg.Contains(".txt")) //если в аргументе содержится
                {
                    files.Add(arg); //тогда это текстовый файл и добавляем его в динамический массив
                }
            }

            foreach (string file in files)
            {

                foreach (string Listtext in Tac(file))
                {
                    Console.WriteLine(Listtext);
                }
            }
           
            return 0;
        }

        /// <summary>
        /// функция читает файл и записывает его в обратном порядке
        /// </summary>
        /// <param name="file">подается имя файла</param>
        /// <returns></returns>
        static List<string> Tac(string file)
        {
            StreamReader sr = new StreamReader(file);

            List<string> tacText = new List<string>();
            string s;

            while (sr.EndOfStream != true)
            {
                s = sr.ReadLine();
                tacText.Add(s);
                //Console.WriteLine(s);
            }

            sr.Close();
            tacText.Reverse();
            return tacText;
        }
       
    }
}
