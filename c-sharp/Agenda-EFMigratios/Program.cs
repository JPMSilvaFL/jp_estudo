using Agenda_EFMigratios.Data;
using Agenda_EFMigratios.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda_EFMigratios;

public class Program {
	public static void Main(string[] args)
	{
		//CriarCliente();
		//LerCliente();
	}

	public static void CriarCliente()
	{
		var pessoa = new Pessoa("04258181202","joao pedro", "joaopedro@gmail.com", "64993140912","av d qd 16 lt12");
		var cliente = new Cliente(pessoa);
		using var context = new AgendaDataContext();

		context.Pessoas.Add(pessoa);
		context.Clientes.Add(cliente);
		Console.Clear();
		context.SaveChanges();
		Console.WriteLine("Cliente cadastrado com sucesso!");
	}

	public static void LerCliente()
	{
		using var context = new AgendaDataContext();
		var clientes = context.Clientes.Include(c=> c.Pessoa).ToList();

		foreach (var cliente in clientes) {
			Console.WriteLine(cliente.Pessoa.FullName);
		}
	}
}