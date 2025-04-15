namespace Teste.Agendamento;

internal class Cliente : Person{
    public Cliente(string cpf, string nome, string email, string contato, string endereco) : base(cpf, nome, email,
        contato, endereco) { }
}