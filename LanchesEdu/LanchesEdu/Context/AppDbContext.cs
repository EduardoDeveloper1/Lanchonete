using LanchesEdu.Models;
using Microsoft.EntityFrameworkCore;
namespace LanchesEdu.Context
{
    public class AppDbContext : DbContext
    {

        //carrega as informações necessarias para configurar o dbcontext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //Define quais classes seram mapeadas para quais tabelas
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoDeComprasItem> CarrinhoDeComprasItens { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
