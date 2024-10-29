using LanchesEdu.Models;
using LanchesEdu.Repositories;
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

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(x => x.IdLanche);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                //if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    lanches = _lancheRepository.Lanches.Where(x => x.Categoria.NomeCategoria.Equals("Normal")).OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    lanches = _lancheRepository.Lanches.Where(x => x.Categoria.NomeCategoria.Equals("Natural")).OrderBy(l => l.Nome);
                //}

                lanches = _lancheRepository.Lanches.Where(x => x.Categoria.NomeCategoria.Equals(categoria)).OrderBy(n => n.Nome);

                categoriaAtual = categoria;
            }

            LancheListViewModel lancheListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lancheListViewModel);
        }

        public IActionResult Details(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(x => x.IdLanche == lancheId);
            return View(lanche);
        }
    }
}