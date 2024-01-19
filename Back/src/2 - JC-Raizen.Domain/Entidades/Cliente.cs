namespace JC_Raizen.Domain.Entidades
{
    public class Cliente
    { 
        //EF
        protected Cliente() { }

        public Cliente(string nome, string email, DateTime dataNascimento, string cEP, string? logradouro, string? complemento, string? bairro, string? localidade, string? uf)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            cep = cEP;
            this.logradouro = logradouro;
            this.complemento = complemento;
            this.bairro = bairro;
            this.localidade = localidade;
            this.uf = uf;
        }

        //Propriedades
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? cep { get; set; }
        public string? logradouro { get; set; }
        public string? complemento { get; set; }
        public string? bairro { get; set; }
        public string? localidade { get; set; }
        public string? uf { get; set; }

    }
}
