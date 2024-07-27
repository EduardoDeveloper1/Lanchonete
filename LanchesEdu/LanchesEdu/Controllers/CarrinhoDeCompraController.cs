using LanchesEdu.Models;
using LanchesEdu.Repositories.Interfaces;
using LanchesEdu.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesEdu.Controllers
{
    public class CarrinhoDeCompraController : Controller
    {

        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoDeCompras _carrinhoDeCompras;


        public CarrinhoDeCompraController(ILancheRepository lancheRepository, CarrinhoDeCompras carrinhoDeCompras)
        {
            _lancheRepository = lancheRepository;
            _carrinhoDeCompras = carrinhoDeCompras;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoDeCompras.GetCarrinhoDeComprasItens();
            _carrinhoDeCompras.CarrinhoDeComprasItens = itens;

            var CarrinhoCompraVM = new CarrinhoDeCompraViewModel
            {
                CarrinhoDeCompras = _carrinhoDeCompras,
                CarrinhoDeCompraToal = _carrinhoDeCompras.GetCarrinhoCompraTotal(),
            };
            return View(CarrinhoCompraVM);
        }

        public IActionResult AdicionarItemNoCarrinho(int id)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(x => x.IdLanche == id);

            if(lancheSelecionado != null)
            {
                _carrinhoDeCompras.AdicionarAoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinho(int id)
        {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(x => x.IdLanche == id);

            if (lancheSelecionado != null)
            {
                _carrinhoDeCompras.RemoverDoCarrinho(lancheSelecionado);
            }

            return RedirectToAction("Index");
        }
    }
}
