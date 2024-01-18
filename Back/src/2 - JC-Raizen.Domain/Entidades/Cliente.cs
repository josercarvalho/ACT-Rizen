namespace JC_Raizen.Domain.Entidades
{
    public class Cliente : Base
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
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public string? CEP { get; private set; }

    }
}
