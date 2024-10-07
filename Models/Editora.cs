using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicShop.Models
{
    [Table("Editora")]
    public class Editora
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEditora { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Nome da editora", Prompt = "Digite o nome da editora", Description = "Nome completo da editora")]
        public string Nome { get; set; }

        [Display(Name = "País de origem", Prompt = "Digite o nome do país de origem", Description = "Nome do país de origem")]
        public string PaisOrigem { get; set; }

        [Range(1000, 2100)]
        [Display(Name = "Ano de fundação", Prompt = "Digite o ano de fundação", Description = "Ano de fundação da editora")]
        public int AnoFundacao { get; set; }

        [Display(Name = "Web Site", Prompt = "Digite o web site", Description = "URL do web site da editora")]
        public string WebSite { get; set; }

        public ICollection<Quadrinho> Quadrinhos { get; set; }
    }
}
