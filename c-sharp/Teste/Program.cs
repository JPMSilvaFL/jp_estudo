using System;
using static System.Threading.Thread;
using Teste.Agendamento;
using Teste.Agendamento.Enums;
using Teste.Agendamento.Notifications;


namespace Teste;

internal class Teste{
    private static void Main(string[] args) {
        var x = 0;

        do {
            Console.Clear();
            Console.WriteLine("Selecione uma das opções abaixo:");
            Console.WriteLine("0- Sair da aplicação.");
            Console.WriteLine("1- Cadastrar Cliente.");
            Console.WriteLine("2- Cadastrar Funcionario.");
            x = int.Parse(Console.ReadLine());
            if (x < 0 || x > 9) Console.WriteLine("Preencha um valor válido!");

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

            if (x == 2) {
                Console.WriteLine("Digite o nome do Funcionario: ");
                var nome = Console.ReadLine();
                Console.WriteLine("Digite o email: ");
                var email = Console.ReadLine();
                Console.WriteLine("Digite o cpf: ");
                var cpf = Console.ReadLine();
                Console.WriteLine("Digite o telefone: ");
                var contato = Console.ReadLine();
                Console.WriteLine("Digite o endereco: ");
                var endereco = Console.ReadLine();
                Console.WriteLine("Selecione um cargo:");
                Console.WriteLine("Medico = 1 \nLimpeza = 2\nAuxiliarGeral = 3");
                var cargo = (ECargos)int.Parse(Console.ReadLine());
                Console.WriteLine("Valor do salário: ");
                var salario = float.Parse(Console.ReadLine());

                var funcionario = new Funcionario(cpf, nome, email, contato, endereco, cargo, salario);
                if (funcionario.HasNotifications() > 0)
                    foreach (var notification in funcionario.Notifications)
                        Console.WriteLine($"{notification.propriedade} - {notification.message}");

                Console.WriteLine(funcionario.cpf);
                Console.WriteLine(funcionario.createdAt);
                Console.WriteLine(funcionario.id);
                Console.WriteLine(funcionario.salario);
                Console.WriteLine(funcionario.cargo.ToString());
                Sleep(5000);
            }
        } while (x != 0);
    }
}