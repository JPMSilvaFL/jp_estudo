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
            Console.WriteLine("3- Deletar");
            Console.WriteLine("0- Sair");
            Console.WriteLine("----------------------------");  
            x = int.Parse(Console.ReadLine());

            switch (x) {
                case 1: break;
                case 2: Criar(); break;
                case 3: break;
            }
        }
        while (x != 0);

    }
    static void Criar() {
        Console.Clear();
        Console.WriteLine("Digite o texto logo abaixo (pressiona ESC para sair):");
        Console.WriteLine("----------------------------------------------------------");

        string text = "";

        do {
            text += Console.ReadLine()+"\n";
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
        
        Salvar(text);
    }
    static void Salvar(string text){
        Console.Clear();

        string path = "C://Users//supor//jp_estudo//c-sharp//TextEditor//myText.txt";

        using(StreamWriter sw = new StreamWriter(path)){
            sw.Write(text);
        }
        Console.WriteLine("Arquivo salvo com sucesso!!");
    }
}