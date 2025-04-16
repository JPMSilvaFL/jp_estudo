namespace Teste.Agendamento;

public class Funcionario : Person{
    public Guid id { get; set; } // Alterar para guid
    public int idCargo { get; set; }
    public DateOnly dataDeIngresso { get; }

    public Funcionario(string cpf, string nome, string email, string contato, string endereco, int cargo) : base(cpf,
        nome,
        email,
        contato,
        endereco) {
        id = Guid.NewGuid();
        idCargo = cargo;
        dataDeIngresso = DateOnly.FromDateTime(DateTime.Now);
    }
}