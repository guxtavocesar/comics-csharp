using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicShop.Models
{
    [Table("Venda")]
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenda { get; set; }

        [Required(ErrorMessage = "Selecione um cliente.")]
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        [Display(Name = "Cliente Associado")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Selecione um quadrinho.")]
        public int IdQuadrinho { get; set; }

        [ForeignKey("IdQuadrinho")]
        [Display(Name = "Quadrinho Vendido")]
        public Quadrinho Quadrinho { get; set; }

        [Required(ErrorMessage = "Informe a quantidade vendida.")]
        [Range(1, 100, ErrorMessage = "A quantidade deve estar entre 1 e 100.")]
        [Display(Name = "Quantidade Vendida", Prompt = "Digite a quantidade")]
        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        [Required(ErrorMessage = "O valor total é obrigatório.")]
        [Display(Name = "Valor Total", Description = "Valor total da venda em reais")]
        public decimal ValorTotal { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data da Venda")]
        public DateTime DataVenda { get; set; } = DateTime.Now;

        // Método para calcular o valor total baseado no preço do quadrinho e quantidade
        public void CalcularValorTotal()
        {
            if (Quadrinho != null)
            {
                ValorTotal = (decimal)(Quadrinho.Preco * Quantidade);
            }
        }
    }
}
