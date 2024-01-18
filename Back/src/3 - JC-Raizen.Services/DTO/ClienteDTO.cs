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
        public string? CEP { get; set; }
        //public virtual EnderecoDTO? EnderecoDTO { get; set; }
    }
}
