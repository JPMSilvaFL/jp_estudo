using Teste.Agendamento.Notifications;

namespace Teste.Agendamento;

public abstract class Person : Base{
    public string id { get; }
    public string cpf { get; set; }
    public string nome { get; set; }
    public string email { get; set; }
    public string contato { get; set; }
    public bool isActive { get; set; }
    public string endereco { get; set; }
    public DateTime createdAt { get; } = DateTime.Now;
    public DateTime updatedAt { get; set; }

    public Person(string cpf, string nome, string email, string contato, string endereco) {
        id = Guid.NewGuid().ToString("N");
        this.cpf = verificaCPF(cpf);

        if (!verificaNome(nome)) {
            this.nome = null;
        }
        else {
            this.nome = nome;
            this.email = email;
            this.contato = contato;
            this.endereco = endereco;
            updatedAt = DateTime.Now;
            isActive = true;
        }
    }

    private string verificaCPF(string cpf) {
        if (string.IsNullOrEmpty(cpf))
            throw new Exception("Preencha corretamente o Cpf");

        cpf = new string(cpf.Where(char.IsDigit).ToArray());
        return cpf;
    }


    private bool verificaNome(string nome) {
        if (nome.Length > 10)
            return true;
        else
            AddNotification(new Notification("Erro", "Nome precisa de ter mais que 10 caracteres"));
        return false;
    }
}