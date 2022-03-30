using System;
using System.Threading;

namespace Lab2_1
{
    internal class Program
    {
        public static int t = 0; //Глобальная переменна от 0 до 50

        public static void Main(string[] args)
        {
            //запуск потока 2
            new Thread(SecondFunc).Start(); //сначала запускаем второй поток
            Console.Read();
        }

        static void FirstFunc()
        {
            //простой рассчёт f по формуле                    
            while (true)
            {
                Console.Out.WriteLine("Первый поток:{0}t  f:{1}",  t, F(t));
                t++;
            }
        }


        static double F(int t) //наша функция от t
        {
           
            return (Math.Sin((2 * Math.PI * t) / 200));
        }

        static void SecondFunc()
        {
            //счётчик обнулений
            int num = 0;
            //запуск первого потока
            var first = new Thread(FirstFunc); //который в свою очередь запускает первый
            first.Start();
            
            while (true)
            {
                if (t ==50)
                {
                    //выбираем убить поток 1 или остановить
                    if (num == 9) first.Abort(); //УБИВАЕМ ПОТОК!!
                    else first.Suspend(); //останавливаем поток
                    //обнуление и инкремент счётчика обнулений
                    t = 0;
                    num++; //нужно так запустить поток 10 раз
                    //вывод в stderr
                    Console.Error.WriteLine("Приостновил num: {0}" , num);
                    //выход из потока 2 или восстановление потока 1
                    if (num == 10) return;
                    if (num != 10) first.Resume(); //возобнавляем работу потока
                }
            }
        }
    }
}