using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicShop.Models
{
    [Table("Fornecedor")]
    public class Fornecedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome", Prompt = "Digite o nome", Description = "Nome completo do fornecedor")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido.")]
        [Display(Name = "E-mail", Prompt = "Digite o e-mail", Description = "E-mail do fornecedor")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [StringLength(11, ErrorMessage = "O telefone deve ter 11 dígitos.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Número de telefone inválido. Deve ser 11 dígitos númericos")]
        [Display(Name = "Telefone", Prompt = "Digite o telefone do fornecedor")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O endereco é obrigatório.")]
        [Display(Name = "Endereco", Prompt = "Digite o endereco", Description = "Endereco do fornecedor")]
        [StringLength(255)]
        public string Endereco { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
