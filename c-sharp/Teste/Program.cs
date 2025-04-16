using System;
using static System.Threading.Thread;
using Teste.Agendamento;
using System.Data.SqlClient;
using Dapper;
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
                Console.WriteLine("Deseja salvar o cliente?");
                Console.WriteLine("1- Sim.");
                Console.WriteLine("2- Não.");
                var i = int.Parse(Console.ReadLine());
                if (i == 1) {
                    var connectionString =
                        "Server=localhost,1433;Database=Curso;User Id=sa;Password=152369Jp@;";

                    using (var connection = new SqlConnection(connectionString)) {
                        connection.Open();

                        // Gera um GUID para o Person (já que usamos NEWSEQUENTIALID no banco, mas queremos controlar o ID aqui)

                        // Inserção na tabela Person
                        var insertPersonSql = @"
                INSERT INTO Person (id, cpf, full_name, email, contato, endereco, createdAt)
                VALUES (@Id,@cpf, @FullName, @Email, @Contato, @Endereco, @CreatedAt);
            ";

                        connection.Execute(insertPersonSql, new {
                            Id = client.id,
                            cpf = int.Parse(client.cpf),
                            FullName = client.full_name,
                            Email = client.email,
                            Contato = client.contato,
                            Endereco = client.endereco,
                            CreatedAt = DateTime.Now
                        });

                        // Inserção na tabela Cliente usando o ID recém-gerado
                        var insertClienteSql = "INSERT INTO Cliente (idPerson) VALUES (@IdPerson);";

                        connection.Execute(insertClienteSql, new { IdPerson = client.id });

                        Console.WriteLine("Inserção concluída com sucesso!");
                    }
                }

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
                var idCargo = int.Parse(Console.ReadLine());


                var funcionario = new Funcionario(cpf, nome, email, contato, endereco, idCargo);

                Console.WriteLine("Deseja salvar funcionário?");
                Console.WriteLine("1- Sim.");
                Console.WriteLine("2- Não.");
                var i = int.Parse(Console.ReadLine());
                if (i == 1) {
                    var connectionString =
                        "Server=localhost,1433;Database=servidorAprendizado;User Id=sa;Password=152369Jp@;";

                    using (var connection = new SqlConnection(connectionString)) {
                        connection.Open();

                        // Gera um GUID para o Person (já que usamos NEWSEQUENTIALID no banco, mas queremos controlar o ID aqui)

                        // Inserção na tabela Person
                        var insertPersonSql = @"
                INSERT INTO Person (id, full_name, email, contato, endereco, createdAt)
                VALUES (@Id, @FullName, @Email, @Contato, @Endereco, @CreatedAt);
            ";

                        connection.Execute(insertPersonSql, new {
                            Id = funcionario.id,
                            FullName = funcionario.full_name,
                            Email = funcionario.email,
                            Contato = funcionario.contato,
                            Endereco = funcionario.endereco,
                            CreatedAt = DateTime.Now
                        });

                        // Inserção na tabela Cliente usando o ID recém-gerado
                        var insertClienteSql = "INSERT INTO Cliente (idPerson) VALUES (@IdPerson);";

                        connection.Execute(insertClienteSql, new { IdPerson = funcionario.id });

                        Console.WriteLine("Inserção concluída com sucesso!");
                    }
                }
            }
        } while (x != 0);
    }
}