using LanchesEdu.Models;

namespace LanchesEdu.Repositories.Interfaces
{
    public interface ICategoriaRepository 
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
