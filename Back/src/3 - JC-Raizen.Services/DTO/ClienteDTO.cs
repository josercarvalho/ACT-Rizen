using System.ComponentModel.DataAnnotations;

namespace JC_Raizen.Services.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "É necessário ser um {0} válido")]
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
