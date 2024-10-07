using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicShop.Models
{
    [Table("Quadrinho")]
    public class Quadrinho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdQuadrinho { get; set; }

        [Required(ErrorMessage = "Campo Titulo é obrigatório")]
        [StringLength(256)]
        [Display(Name = "Título", Prompt = "Digite o título do quadrinho", Description = "Título completo do quadrinho")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Autor é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Nome do autor", Prompt = "Digite o nome do autor", Description = "Nome completo do autor")]
        public string Autor { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Required(ErrorMessage = "Campo Preco unitário é obrigatório")]
        [Display(Name = "Preço unitário", Description = "Valor do quadrinho em reais")]
        public float Preco { get; set; }

        [Required(ErrorMessage = "Selecione uma editora.")]
        public int IdEditora { get; set; }

        [Required(ErrorMessage = "Campo Estoque é obrigatório")]
        [Display(Name = "Quantidade de estoque", Prompt = "Informe a quantidade", Description = "Quantidade de estoque")]
        public int QuantidadeEstoque { get; set; }

        [ForeignKey("IdEditora")]
        [Display(Name = "Editora Associada")]
        public Editora Editora { get; set; }

        [Required(ErrorMessage = "Selecione um fornecedor.")]
        public int IdFornecedor { get; set; }

        [ForeignKey("IdFornecedor")]
        [Display(Name = "Fornecedor Associado")]
        public Fornecedor Fornecedor { get; set; }
    }
}
