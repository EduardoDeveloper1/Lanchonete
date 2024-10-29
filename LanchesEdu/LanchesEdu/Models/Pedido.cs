using Microsoft.Build.Evaluation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesEdu.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(60)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Sobrenome")]
        [StringLength(60)]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Informe o Endereço")]
        [StringLength(100)]
        public string Endereco1 { get; set; }
        [StringLength(100)]
        [Display(Name = "Complemento")]
        public string Endereco2 { get; set; }
        [Required(ErrorMessage = "Informe o cep")]
        [StringLength(10, MinimumLength = 8)]
        public string Cep { get; set; }
        [StringLength(10)]
        public string Estado { get; set; }
        [StringLength(50)]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Informe o telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Informe o e-mail")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total do Pedido")]
        public decimal PedidoTotal { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "Itens do Pedido")]
        public int TotalItensPedido { get; set; }
        [Display(Name = "Data do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/mm/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; }
        [Display(Name = "Data do Envio do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/mm/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? PedidoEntregue { get; set; }

        public List<PedidoDetalhe> PedidoItens { get; set;}

    }
}
