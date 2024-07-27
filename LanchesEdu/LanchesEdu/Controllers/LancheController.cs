using LanchesEdu.Repositories.Interfaces;
using LanchesEdu.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesEdu.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        //usa a injeção de dependencia para a interface lanche repository para que assim possamos acessar os dados
        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            //ViewData["Titulo"] = "Todos os Lanches";
            //ViewData["Hora"] = DateTime.Now;
            //var lanches = _lancheRepository.Lanches;
            //return View(lanches);// retorna os dados dentro da view

            LancheListViewModel lancheListViewModel = new LancheListViewModel();
            lancheListViewModel.Lanches = _lancheRepository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";
            return View(lancheListViewModel);
        }
    }
}
