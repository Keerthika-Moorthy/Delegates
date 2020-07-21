using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;



namespace DelegatesThread

{ 
    class Program
    {
       
        public delegate void TestDelegate();
        static TestDelegate TestD = Print;
        static Action testAction = PrintHello;
        static void Main(string[] args)
        {
            goto TASKSECTION;
        DELEGATESECTION:
            Action test = () => { Console.WriteLine("Hi"); Console.WriteLine("Welcome"); };
            test.Invoke();
            Action<string> printGiven = (a) => { Console.WriteLine(a); };
            printGiven.Invoke("How Are u");
            Console.WriteLine("-----------------------------------------------------------------");
            Action<string, int> printGivenNumberofTimes = (s, n) =>
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine(s);
                    }
                };
            printGivenNumberofTimes.Invoke("Iam Fine", 6);
            Console.WriteLine("------------------------");

        THREADINDSECTION:

            Thread th1 = new Thread(new ThreadStart(() =>
              {
                  for (int i = 0; i < 10; i++)
                  {
                      Console.WriteLine($"{DateTime.Now.ToString("yyyy/mm/dd HH:MM:ss")} :thread 1----{i.ToString()}");
                      Thread.Sleep(1000);

                  }
              }));
            Thread th2 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{DateTime.Now.ToString("yyyy/mm/dd HH:MM:ss")} :thread 1----{i.ToString()}");
                    Thread.Sleep(1000);

                }
            }));
            th1.Start();
            th2.Start();
            Console.WriteLine($"{DateTime.Now.ToString("yyyy/mm/dd HH:MM:ss")}:Main Thread");


        TASKSECTION:

            TestAsync();
        }

        public static void Print()
        {
            Console.WriteLine("Heloo");
        }
        public static void PrintHello()
        {
            Console.WriteLine("Keerthi");
        }
        public static async void TestAsync()
        {
            Task task2 = new Task(() =>
              {
                  for (int i = 0; i < 10; i++)
                  {
                      Console.WriteLine($"{DateTime.Now.ToString("yyyy / mm / dd HH: MM:ss")}:Task 2----{i.ToString()}");
                      Thread.Sleep(1000);
                  }
              });
            FirstTask();
            task2.Start();
            Console.WriteLine($"{DateTime.Now.ToString("yyyy/mm/dd HH:MM:ss")}:Main Thread");
            Console.ReadLine();

        }
        public static async void FirstTask()
        {
            Task<int> task1 = new Task<int>(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{DateTime.Now.ToString("yyyy / mm / dd HH: MM:ss")}:Task 1----{i.ToString()}");
                    Thread.Sleep(1000);
                }
                return 5;
            });
           
            task1.Start();
            Console.WriteLine($"{DateTime.Now.ToString("yyyy/mm/dd HH:MM:ss")}:Main Thread");
            Console.ReadLine();

        }



    }
}

