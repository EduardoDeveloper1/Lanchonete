using System.ComponentModel.DataAnnotations;

namespace LanchesEdu.Models
{
    public class Lanche
    {
        [Key]
        public int IdLanche { get; set; }
        [Required (ErrorMessage = "O nome do lanche deve ser informado")]
        [Display (Name = "Nome do lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no minimo {1} e no máximo {2} ")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A descrição do lanche deve ser informado")]
        [Display(Name = "Descrição do lanche")]
        [MinLength(20, ErrorMessage = "A descrição deve ter no minimo 1 caractere!")]
        [MaxLength(200, ErrorMessage = "A descrição pode exceder {1} caracteres")]
        public string DescricaoCurta { get; set; }
        [Required(ErrorMessage = "A descrição detalahada do lanche deve ser informado")]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "A descrição detalhada deve ter no minimo 1 caractere!")]
        [MaxLength(200, ErrorMessage = "A descrição detalhada pode exceder {1} caracteres")]
        public string DescricaoDetalhada { get; set; }
        [Required(ErrorMessage = "Informe o preço do lanche")]
        [Display(Name = "Preço")]
        [Range(1,99.99, ErrorMessage = "O preço deve ser entre e no máximo 99.99")]
        public double Preco { get; set; }
        [Display(Name = "Caminho da imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemURL { get; set; }
        [Display(Name = "Caminho da imagem em Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailURL { get; set; }
        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }
        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
        // Dessa forma especificamos que a classe lanche tem uma relação com a classe Categoria
    }
}
