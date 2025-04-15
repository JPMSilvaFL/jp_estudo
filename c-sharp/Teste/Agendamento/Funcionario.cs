using Teste.Agendamento.Enums;

namespace Teste.Agendamento;

public class Funcionario : Person{
    public string id { get; set; }
    public ECargos cargo { get; set; }
    public float salario { get; set; }
    public DateOnly createdAt { get; }

    public Funcionario(string cpf, string nome, string email, string contato, string endereco, ECargos cargo,
                       float salario) : base(cpf, nome,
        email, contato, endereco) {
        id = Guid.NewGuid().ToString("N");
        this.cargo = cargo;
        this.salario = salario;
        createdAt = DateOnly.FromDateTime(DateTime.Now);
    }
}