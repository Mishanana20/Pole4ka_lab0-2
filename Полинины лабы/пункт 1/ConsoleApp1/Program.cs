/*
 Читаемый файл (текстовый в формате .txt)
должен лежлать в папке "bin/Debug/ " и называться как "fileProb.txt"
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;


namespace ConsoleApp1
{
    class Program
    {
        static int Compare(int a, int b)
        {
            if (a > b)
            {
                return b;
            }
            if (b > a)
            {
                return a;
            }
            if (a == b)
            {
                return a;
            }
           else return 0;
        }

        static void CoutToConsole(int currentLine, string[] array)  //функция вывода в консоль
        {
            if (array.Length != 0)
            {
                Console.Clear(); //очищаем консоль
                for (int i = currentLine; i < Compare(currentLine + 24, array.Length+1); i++) //смещаем позицию (строку), с которой читаем текст 
                {
                    if (i < array.Length)
                    {
                        Console.WriteLine(array[i], '\n');
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25); //задаем размер консоли
            char ch;
            string s = "";
            int currentLine = 0;
            List<string> text = new List<string>(); //лист для записи текста
            StreamReader reader;
            reader = new StreamReader("fileProb.txt", System.Text.Encoding.UTF8);  //путь к читаемому файлу в кодировке utf-8. НАХОДИТСЯ В ПАПКЕ /bin/Debug/
            while (!reader.EndOfStream) //начинаем читать файл пока не достигнем его конца
            {
              
                s = reader.ReadLine(); //читаем строку
                if (s.Length >= 80)
                {
                    s = s.Substring(0, 80); //если прочитанная строка больше 80 символов, то обрезаем её
                }
                text.Add(s); //добавляем её в массив (Лист)
                s = "";
            }
            //reader.Close();
            //reader.Dispose();
           
            Console.SetCursorPosition(0, 0); //устанавливаем позицию курсора
            Console.Clear();
            string[] array = text.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (i < 24)
                {
                    Console.WriteLine(array[i], '\n');
                }
            }

            while (true) //бесконечный цикл для промотки текста в консоли
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow) //если нажата стрелка вверх
                {
                    if (currentLine > 0)
                    {
                        currentLine--;
                        CoutToConsole(currentLine, array);
                    }
                }
                if (key == ConsoleKey.DownArrow)
                {
                    if (currentLine < array.Length) //если нажали стрелку вниз
                    {
                        currentLine++;
                        CoutToConsole(currentLine, array);
                    }
                }
            
            }
        }
        }
}
