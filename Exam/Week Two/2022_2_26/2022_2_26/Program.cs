// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main(string[] args)
    {
        Thread thread = new Thread(Show);
        thread.Start();
    }

    static void Show()
    {
        string words = "我是科瑞恩软件工程部的一员，进步最快的那位...";
        foreach (char item in words)
        {
            Console.Write(item);
            Thread.Sleep(200);
        }
        Console.Read();
    }
}

