using LanchesEdu.Models;

namespace LanchesEdu.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }

        public string CategoriaAtual { get; set; }
    }
}
