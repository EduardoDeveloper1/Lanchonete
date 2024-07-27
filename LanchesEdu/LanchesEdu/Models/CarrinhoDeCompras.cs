using LanchesEdu.Context;
using Microsoft.EntityFrameworkCore;


namespace LanchesEdu.Models
{
    public class CarrinhoDeCompras
    {
        private readonly AppDbContext _context;

        public CarrinhoDeCompras(AppDbContext context)
        {
            _context = context; 
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoDeComprasItem> CarrinhoDeComprasItens { get; set; }


        public static CarrinhoDeCompras GetCarrinho(IServiceProvider serviceProvider)
        {
            //Define uma sessão e verifica se a instancia de HttpContextAccessor é nula, caso não seja  ele invoca e retorna uma session
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtem um srviço do tipo do nosso contexto
            var context = serviceProvider.GetService<AppDbContext>();

            //Obtem ou gera o id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //Atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //Retornar o carrinho com o contexto e o id atribuido ou obtido
            return new CarrinhoDeCompras(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche)
        {
            CarrinhoDeComprasItem carrinhoDeComprasItem = _context.CarrinhoDeComprasItens.SingleOrDefault(x => x.Lanche.IdLanche == lanche.IdLanche
            && x.CarrinhoCompraId == CarrinhoCompraId);


            //Verifica se o carrinho é nulo caso seja cria a instancia e adiciona os valores
            if (carrinhoDeComprasItem == null)
            {
                carrinhoDeComprasItem = new CarrinhoDeComprasItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoDeComprasItens.Add(carrinhoDeComprasItem);
            }
            else
            {
                carrinhoDeComprasItem.Quantidade++;
            }

            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
            CarrinhoDeComprasItem carrinhoDeComprasItem;
            carrinhoDeComprasItem = _context.CarrinhoDeComprasItens.SingleOrDefault(x => x.Lanche.IdLanche == lanche.IdLanche &&
            x.CarrinhoCompraId == CarrinhoCompraId);

            int QuantidadeLocal = 0;

            if (carrinhoDeComprasItem != null)
            {
                if (carrinhoDeComprasItem.Quantidade > 1)
                {
                    carrinhoDeComprasItem.Quantidade--;
                    QuantidadeLocal = carrinhoDeComprasItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoDeComprasItens.Remove(carrinhoDeComprasItem);
                }
            }

            _context.SaveChanges();
            return QuantidadeLocal;
        }

        public List<CarrinhoDeComprasItem> GetCarrinhoDeComprasItens()
        {
            return CarrinhoDeComprasItens ?? (CarrinhoDeComprasItens = 
                _context.CarrinhoDeComprasItens.Where(x => CarrinhoCompraId == CarrinhoCompraId).Include(x => x.Lanche).ToList());
        }

        public void LimparCarrinho()
        {
            CarrinhoDeComprasItem carrinhoItens = (CarrinhoDeComprasItem)_context.CarrinhoDeComprasItens.Where(x => x.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoDeComprasItens.RemoveRange(carrinhoItens);

            _context.SaveChanges();
        }

        public double GetCarrinhoCompraTotal()
        {
            double total = _context.CarrinhoDeComprasItens.Where(x => x.CarrinhoCompraId == CarrinhoCompraId).Select(p => p.Lanche.Preco * p.Quantidade).Sum();
            return total;
        }
    }
}
