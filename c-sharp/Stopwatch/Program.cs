using System;
using System.Threading;
namespace Stopwatch;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Quantos segundos o cronometro continuara?");
        int t = int.Parse(Console.ReadLine());


        int i = 0;
        int tempoG = 0;
        while (tempoG <= t)
        {
            for (int j = 0; j <= 59; j++)
            {
                for (int k = 0; k <= 59; k++)
                {
                    tempoG++;
                    Console.Clear();
                    if (tempoG == t)
                    {
                        Console.WriteLine(i + ":" + j + ":" + k);
                        return;
                    }
                    Console.WriteLine(i + ":" + j + ":" + k);
                    Thread.Sleep(1);
                }
            }
        i++;
        }

    }
}

