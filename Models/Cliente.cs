using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicShop.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome", Prompt = "Digite o nome", Description = "Nome completo do cliente")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido.")]
        [StringLength(255)]
        [Display(Name = "E-mail", Prompt = "Digite o e-mail", Description = "E-mail do cliente")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        // Método para garantir o armazenamento do e-mail em minúsculas
        public void SetEmail(string email)
        {
            Email = email.ToLowerInvariant();
        }
    }
}
