using LanchesEdu.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesEdu.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {
            //var categoria = _categoriaRepository.Categorias.OrderBy(x => x.NomeCategoria).FirstOrDefault();
            //return View(categoria);
                var categorias = _categoriaRepository.Categorias.OrderBy(x => x.NomeCategoria).ToList();
                return View(categorias);
            

        }
    }
}
