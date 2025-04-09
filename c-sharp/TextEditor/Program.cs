using System;
using System.IO;
using System.Threading;

class TextEditor{
    static void Main(string[] main) {
        int x = 0;
        do {
            Console.Clear();
            Console.WriteLine("Escolha uma das opções:");
            Console.WriteLine("1- Editar");
            Console.WriteLine("2- Criar");
            Console.WriteLine("0- Sair");
            Console.WriteLine("----------------------------");
            x = int.Parse(Console.ReadLine());

            switch (x) {
                case 1: Console.WriteLine("Editado!!"); break;
                case 2: Console.WriteLine("Criado!!"); break;
            }
            Thread.Sleep(1000);
        }
        while (x != 0);
    }
}