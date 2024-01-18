namespace JC_Raizen.Domain.Entidades
{
    public class Cliente
    { 
        //EF
        protected Cliente() { }

        public Cliente(string nome, string email, DateTime dataNascimento, string cEP)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            CEP = cEP;
        }

        //Propriedades
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? CEP { get; set; }

    }
}
