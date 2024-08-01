using LanchesEdu.Migrations;
using LanchesEdu.Models;
using LanchesEdu.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace LanchesEdu.Components
{
    public class CarrinhoDeCompraResumo : ViewComponent
    {
        private readonly CarrinhoDeCompras _carrinhoDeCompras;

        public CarrinhoDeCompraResumo(CarrinhoDeCompras carrinhoDeCompras)
        {
            _carrinhoDeCompras = carrinhoDeCompras;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _carrinhoDeCompras.GetCarrinhoDeComprasItens();
            _carrinhoDeCompras.CarrinhoDeComprasItens = itens;

            var CarrinhoCompraVM = new CarrinhoDeCompraViewModel
            {
                CarrinhoDeCompras = _carrinhoDeCompras,
                CarrinhoDeCompraTotal = _carrinhoDeCompras.GetCarrinhoCompraTotal(),
            };
            return View(CarrinhoCompraVM);
        }

    }
}
