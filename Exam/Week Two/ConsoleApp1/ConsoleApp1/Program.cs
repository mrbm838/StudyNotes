// See https://aka.ms/new-console-template for more information
//using System;

class Program
{
    static void Main(string[] args)
    {
        string words = "我是科瑞恩软件工程部的一员，进步最快的那位...";

        //Thread thread = new Thread(ThreadSleepMethod);
        //thread.Start(words);

        //TaskMethod(words);

        //Task.Delay(200).ContinueWith(_ => Console.WriteLine(words));

        //foreach (char item in words)
        //{
        //    //Console.Write(item);
        //    Task.Delay(1000).ContinueWith(_ => Console.WriteLine(item));
        //}
        string a = words.Remove(0, 1);
        char b = words[0];
        Console.WriteLine(a);
        Console.WriteLine(words);
        Console.WriteLine(b);

        Console.Read();

    }

    static void ThreadSleepMethod(object str)
    {
        string charArray = str as string;
        foreach (char item in charArray)
        {
            Console.Write(item);
            Thread.Sleep(200);
        }
    }

    static void TaskMethod(string str)
    {
        Task.Run(() =>
        {
            foreach (char item in str)
            {
                Console.Write(item);
                Thread.Sleep(200);
            }
        });
    }
}
