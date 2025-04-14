namespace Persons{
    public abstract class Person{
        
        public Guid id { get; }
        public string cpf { get; set; }
        public string nome{ get; set; }
        public string email{ get; set; }
        public string contato{ get; set; }
        public bool isActive{ get; set; }
        public string endereco{ get; set; }
        public DateTime createdAt { get; } = DateTime.Now;
        public DateTime updatedAt { get; set; }

        public Person(string cpf, string nome, string email, string contato, string endereco) {
            this.id = Guid.NewGuid();
            this.cpf = cpf;
            this.nome = nome;
            this.email = email;
            this.contato = contato;
            this.endereco = endereco;
            this.updatedAt = DateTime.Now;
            this.isActive = true;
        }
    }
}