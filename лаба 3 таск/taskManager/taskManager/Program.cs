using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace taskManager
{
    class TaskObj {
        public String taskName;
        public int taskPID;
        public double taskCPU;
        public double taskRAM;

        private  DateTime lastTime;
        private TimeSpan lastTotalProcessorTime;
        private DateTime curTime;
        private TimeSpan curTotalProcessorTime;

        public TaskObj(String _taskName, int _taskPID, double _taskRAM)
        {
            this.taskName = _taskName;
            this.taskPID = _taskPID;
            this.taskRAM = _taskRAM;
            this.taskCPU = 0.0;
        }

        public void CpuUsage()
        {
            var result_cpu_usage = 0.0;
            Process[] processListFromCPUUsage = Process.GetProcessesByName(taskName);

            if (processListFromCPUUsage.Length != 0)
            {
                Process processFromCPUUsage = processListFromCPUUsage[0];
                if (this.lastTime == null || this.lastTime == new DateTime())
                {
                    this.lastTime = DateTime.Now;
                    this.lastTotalProcessorTime = processFromCPUUsage.TotalProcessorTime;
                }
                else
                {
                    this.curTime = DateTime.Now;
                    this.curTotalProcessorTime = processFromCPUUsage.TotalProcessorTime;

                    double CPUUsage = (this.curTotalProcessorTime.TotalMilliseconds - this.lastTotalProcessorTime.TotalMilliseconds) 
                        / this.curTime.Subtract(lastTime).TotalMilliseconds 
                        / Convert.ToDouble(Environment.ProcessorCount);
                    this.lastTime = this.curTime;
                    this.lastTotalProcessorTime = this.curTotalProcessorTime;
                    this.taskCPU = (CPUUsage * 100);
                }
            }
            else
            {
                this.taskCPU = result_cpu_usage;
            }

        }
    }
    class Program
    {
        public static Process[] listOfProcesses = Process.GetProcesses();
        public static List<Process> tempProcessesList;

        private static List<TaskObj> listOfTask = new();
        private static List<TaskObj> sortedList = new();

        public static int item = 0;
        public static int processesLength = listOfProcesses.Length;

        public static int sortByName = 1;
        public static int sortByPID = 0;
        public static int sortByRAM = 0;
        public static int sortByCPU = 0;

        internal static List<TaskObj> ListOfTask { get => listOfTask; set => listOfTask = value; }

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
            return 0;
        }
        static void output()
        {
            while (true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);

                getInfo();

                foreach(var proc in ListOfTask)
                {
                    proc.CpuUsage();
                }

                if (sortByName == 1)
                {
                    Console.WriteLine("{0,-5}   {1,-35} {2,-5} \t {3,-7}      {4,-20}", "№", "Name↓", "Ram", "PID", "CPU");
                    sortedList = ListOfTask.OrderBy(X => X.taskName).ToList();
                }

                if (sortByName == 2) {
                    Console.WriteLine("{0,-5}   {1,-35} {2,-5} \t {3,-7}      {4,-20}", "№", "Name↑", "Ram", "PID", "CPU");
                    sortedList = ListOfTask.OrderBy(X => X.taskName).ToList();
                    sortedList.Reverse();
                }

                if (sortByPID == 1)
                {
                    Console.WriteLine("{0,-5}   {1,-35} {2,-5} \t {3,-7}      {4,-20}", "№", "Name", "Ram", "PID↓", "CPU");
                    sortedList = ListOfTask.OrderBy(X => X.taskPID).ToList();
                }

                if (sortByPID == 2)
                {
                    Console.WriteLine("{0,-5}   {1,-35} {2,-5} \t {3,-7}      {4,-20}", "№", "Name", "Ram", "PID↑", "CPU");
                    sortedList = ListOfTask.OrderBy(X => X.taskPID).ToList();
                    sortedList.Reverse();
                }

                if (sortByRAM == 1)
                {
                    Console.WriteLine("{0,-5}   {1,-35} {2,-5} \t {3,-7}      {4,-20}", "№", "Name", "Ram↓", "PID", "CPU");
                    sortedList = ListOfTask.OrderBy(X => X.taskRAM).ToList();
                }

                if (sortByRAM == 2)
                {
                    Console.WriteLine("{0,-5}   {1,-35} {2,-5} \t {3,-7}      {4,-20}", "№", "Name", "Ram↑", "PID", "CPU");
                    sortedList = ListOfTask.OrderBy(X => X.taskRAM).ToList();
                    sortedList.Reverse();
                }

                if (sortByCPU == 1)
                {
                    Console.WriteLine("{0,-5}   {1,-35} {2,-5} \t {3,-7}      {4,-20}", "№", "Name", "Ram", "PID", "CPU↑");
                    sortedList = ListOfTask.OrderBy(X => X.taskCPU).ToList();
                }

                if (sortByCPU == 2)
                {
                    Console.WriteLine("{0,-5}   {1,-35} {2,-5} \t {3,-7}      {4,-20}", "№", "Name", "Ram", "PID", "CPU↓");
                    sortedList = ListOfTask.OrderBy(X => X.taskCPU).ToList();
                    sortedList.Reverse();
                }


                Console.WriteLine("-------------------------------------------------------------------------------------------");

                for (int i = item; i < Compare(item + 28, sortedList.Count); i++)
                {

                    Console.WriteLine("{0,-5}   {1,-35} {2,-5}M \t {3,-7} \t {4,-7:###.##}%", i, sortedList[i].taskName, sortedList[i].taskRAM, sortedList[i].taskPID, sortedList[i].taskCPU);
                }
                Thread.Sleep(10);
            }
        }

        static void getInfo()
        {
            ListOfTask.Clear();

            listOfProcesses = Process.GetProcesses();
            tempProcessesList = listOfProcesses.ToList();

            for(int i = 1; i < tempProcessesList.Count; i++)
            {
                TaskObj task = new(
                        tempProcessesList[i].ProcessName,
                        tempProcessesList[i].Id,
                        tempProcessesList[i].PrivateMemorySize64 / 1000000L
                        );

                task.CpuUsage();
                ListOfTask.Add(task);
            }

        }
       


        static void Main(string[] args)
        {
            Console.Title = "TaskManager";
            Console.SetWindowSize(90, 31);
            var taskManager = new Thread(output);
            taskManager.Start();

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    if (item > 0)
                    {
                        item--;
                    }
                }
                if (key == ConsoleKey.DownArrow)
                {
                    if (item < processesLength)
                    {
                        item++;
                    }

                    if (item > processesLength - 28)
                    {
                        item = processesLength - 28;
                    }
                }

                if (key == ConsoleKey.Q)
                {
                    if(sortByName == 0 || sortByName == 2)
                    {
                        sortByName = 1;
                        sortByCPU = 0;
                        sortByPID = 0;
                        sortByRAM = 0;
                    } else
                    if (sortByName == 1) {
                        sortByName = 2;
                        sortByCPU = 0;
                        sortByPID = 0;
                        sortByRAM = 0;
                    }
                }

                if (key == ConsoleKey.W)
                {
                    if (sortByRAM == 0 || sortByRAM == 2)
                    {
                        sortByRAM = 1;
                        sortByCPU = 0;
                        sortByPID = 0;
                        sortByName = 0;
                    }
                    else
                    if (sortByRAM == 1)
                    {
                        sortByRAM = 2;
                        sortByCPU = 0;
                        sortByPID = 0;
                        sortByName = 0;
                    }
                }
                if (key == ConsoleKey.E)
                {
                    if (sortByPID == 0 || sortByPID == 2)
                    {
                        sortByPID = 1;
                        sortByCPU = 0;
                        sortByRAM = 0;
                        sortByName = 0;
                    }
                    else
                    if (sortByPID == 1)
                    {
                        sortByPID = 2;
                        sortByCPU = 0;
                        sortByRAM = 0;
                        sortByName = 0;
                    }
                }
                if (key == ConsoleKey.R)
                {
                    if (sortByCPU == 0 || sortByCPU == 2)
                    {
                        sortByCPU = 1;
                        sortByPID = 0;
                        sortByRAM = 0;
                        sortByName = 0;
                    } else
                    if (sortByCPU == 1)
                    {
                        sortByCPU = 2;
                        sortByPID = 0;
                        sortByRAM = 0;
                        sortByName = 0;
                    }
                }


                if (key == ConsoleKey.Escape)
                {
                    taskManager.Abort();
                    break;
                }
            }
        }
    }
}
