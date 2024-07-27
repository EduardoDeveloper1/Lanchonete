using System.ComponentModel.DataAnnotations;

namespace LanchesEdu.Models
{
    public class CarrinhoDeComprasItem
    {
        [Key]
        public int CarrinhoCompraItemId { get; set; }
        public Lanche Lanche { get; set; }
        public int Quantidade { get; set; }
        [StringLength (200)]
        public string CarrinhoCompraId { get; set; }
    }
}
