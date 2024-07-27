using System.ComponentModel.DataAnnotations;

namespace LanchesEdu.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [StringLength(100, ErrorMessage = "Tamanho máximo de 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display (Name = "Nome da Categoria")]
        public string NomeCategoria { get; set; }
        [StringLength(200, ErrorMessage = "Tamanho máximo de 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public List<Lanche> Lanches { get; set; }
    }
}
