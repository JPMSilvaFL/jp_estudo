using System;
using static System.Threading.Thread;
using Teste.Agendamento;
using System.Data.SqlClient;
using Dapper;


namespace Teste;

internal class Teste {
	private static void Main(string[] args)
	{
		// SalvarClienteLista();
		SalvarFuncionarioLista();
	}

	public static void SalvarCliente()
	{
		var pessoa = new Person("04258181102", "joao pedro mota", "joao@gmail.com", "64993140912", "adadmaljdkma");
		var client = new Cliente(pessoa);


		Console.Clear();


		var connectionString = "Server=localhost,1433;Database=Curso;User Id=sa;Password=152369Jp@;";

		using (var connection = new SqlConnection(connectionString)) {
			connection.Open();

			var insertPersonSql = @"
                INSERT INTO Person (id, cpf, full_name, email, contato, endereco, createdAt)
                VALUES (@Id,@Cpf, @FullName, @Email, @Contato, @Endereco, @CreatedAt);";

			connection.Execute(insertPersonSql,
				new {
					pessoa.Id,
					pessoa.Cpf,
					pessoa.FullName,
					pessoa.Email,
					pessoa.Contato,
					pessoa.Endereco,
					pessoa.CreatedAt
				});

			var insertClienteSql = "INSERT INTO Cliente (id, idPerson) VALUES (@Id, @IdPerson);";

			connection.Execute(insertClienteSql,
				new {
					client.Id,
					IdPerson = pessoa.Id
				});

			Console.WriteLine(
				"Inserção concluída com sucesso!");
		}
	}

	public static void SalvarClienteLista()
	{
		var pessoas = new List<Person> {
			new("04258181102", "joao pedro", "joao@gmail.com", "9651412351", "dbadbakhj"),
			new("15796314796", "joao mota", "pedro@gmail.com", "465845215", "ajdnadja"),
			new("15796314797", "luiz", "luiz@gmail.com", "465845215", "ajdnadja"),
			new("15796314798", "lucas", "lucas@gmail.com", "465845215", "ajdnadja"),
			new("15796314799", "carlos", "carlos@gmail.com", "465845215", "ajdnadja"),
			new("15796314710", "maria", "maria@gmail.com", "465845215", "ajdnadja"),
			new("15796314755", "naire", "naire@gmail.com", "465845215", "ajdnadja")
		};
		var clientes = new List<Cliente>();
		foreach (var pessoa in pessoas) clientes.Add(new Cliente(pessoa));


		var connectionString = "Server=localhost,1433;Database=Curso;User Id=sa;Password=152369Jp@;";

		var insertPersonSql = @"
                INSERT INTO Person (id, cpf, full_name, email, contato, endereco, createdAt)
                VALUES (@Id,@Cpf, @FullName, @Email, @Contato, @Endereco, @CreatedAt);";

		var insertClienteSql = "INSERT INTO Cliente (id, idPerson) VALUES (@Id, @IdPerson);";

		using (var connection = new SqlConnection(connectionString)) {
			connection.Open();
			foreach (var cliente in clientes) {
				connection.Execute(insertPersonSql,
					new {
						cliente.Pessoa.Id,
						cliente.Pessoa.Cpf,
						cliente.Pessoa.FullName,
						cliente.Pessoa.Email,
						cliente.Pessoa.Contato,
						cliente.Pessoa.Endereco,
						cliente.Pessoa.CreatedAt
					});
				connection.Execute(insertClienteSql,
					new {
						cliente.Id,
						IdPerson = cliente.Pessoa.Id
					});
			}

			Console.WriteLine("Inserção concluída com sucesso!");
		}
	}

	public static void SalvarCargoLista()
	{
		var cargos = new List<Cargos> {
			new("Medico", "Atender paciente", 5000.01),
			new("Atendente", "Atender paciente", 5000.01),
			new("Limpeza", "Atender paciente", 5000.01),
			new("Contador", "Atender paciente", 5000.01),
			new("Recepcionista", "Atender paciente", 5000.01)
		};
		var connectionString = "Server=localhost,1433;Database=Curso;User Id=sa;Password=152369Jp@;";

		var insertCargosSql = @"
                INSERT INTO Cargos (id, nome, descricao, salario)
                VALUES (@Id,@Nome, @Descricao, @Salario);";


		using (var connection = new SqlConnection(connectionString)) {
			connection.Open();
			foreach (var cargo in cargos)
				connection.Execute(insertCargosSql,
					new {
						cargo.Id,
						cargo.Nome,
						cargo.Descricao,
						cargo.Salario
					});

			Console.WriteLine("Inserção concluída com sucesso!");
		}
	}

	public static void SalvarFuncionarioLista()
	{
		var connectionString = "Server=localhost,1433;Database=Curso;User Id=sa;Password=152369Jp@;";

		var cargos = new List<Cargos>();
		var pessoas = new List<Person>();
		using (var connection = new SqlConnection(connectionString)) {
			connection.Open();
			pessoas = connection
				.Query<Person>(
					"SELECT id as Id, cpf as Cpf, full_name as FullName, email as Email, contato as Contato, isActive as IsActive, endereco as Endereco, createdAt as CreatedAt, updatedAt as UpdatedAt FROM Person;")
				.Select(row => new Person() {
					Id = row.Id,
					Cpf = row.Cpf,
					FullName = row.FullName,
					Email = row.Email,
					Contato = row.Contato,
					IsActive = row.IsActive,
					Endereco = row.Endereco,
					CreatedAt = row.CreatedAt,
					UpdatedAt = row.UpdatedAt
				})
				.ToList();
			cargos = connection.Query<Cargos>("Select * from Cargos ")
				.Select(rows => new Cargos() {
					Id = rows.Id,
					Nome = rows.Nome,
					Descricao = rows.Descricao,
					Salario = rows.Salario
				}).ToList();
		}

		var funcionarios = new List<Funcionario>();

		for (var i = 0; i < cargos.Count; i++) funcionarios.Add(new Funcionario(cargos[i], pessoas[i]));

		var insertFuncionariosSql = @"
		              INSERT INTO Funcionarios (id, idPerson, idCargo, dataDeIngresso)
		              VALUES (@Id,@IdPessoa, @IdCargo, @DataDeIngresso);";

		using (var connection = new SqlConnection(connectionString)) {
			connection.Open();
			foreach (var funcionario in funcionarios)
				connection.Execute(insertFuncionariosSql,
					new {
						funcionario.Id,
						IdPessoa = funcionario.Pessoa.Id,
						IdCargo = funcionario.Cargo.Id,
						funcionario.DataDeIngresso
					});

			Console.WriteLine("Inserção concluída com sucesso!");
		}
	}
}