using System;
using Persons;
using static System.Threading.Thread;


namespace Application;

internal class Teste{
    private static void Main(string[] args) {
        var x = 0;

        do {
            Console.Clear();
            Console.WriteLine("Selecione uma das opções abaixo:");
            Console.WriteLine("0- Sair da aplicação.");
            Console.WriteLine("1- Cadastrar Cliente.");
            x = int.Parse(Console.ReadLine());
            if (x < 0 || x > 9) Console.WriteLine("Preencha um valor válido!");
            try {
                if (x == 1) {
                    Console.WriteLine("Digite o nome do cliente: ");
                    var nome = Console.ReadLine();
                    Console.WriteLine("Digite o email: ");
                    var email = Console.ReadLine();
                    Console.WriteLine("Digite o cpf: ");
                    var cpf = Console.ReadLine();
                    Console.WriteLine("Digite o telefone: ");
                    var contato = Console.ReadLine();
                    Console.WriteLine("Digite o endereco: ");
                    var endereco = Console.ReadLine();

                    var client = new Cliente(cpf, nome, email, contato, endereco);
                    Console.WriteLine(client.cpf);
                    Console.WriteLine(client.createdAt);
                    Console.WriteLine(client.id);
                    Sleep(5000);
                }
            }
            catch (Exception e) {
                Console.WriteLine("Erro: " + e.Message);
            }
        } while (x != 0);
    }
}