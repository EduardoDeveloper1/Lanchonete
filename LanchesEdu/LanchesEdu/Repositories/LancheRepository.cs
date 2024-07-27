using LanchesEdu.Context;
using LanchesEdu.Models;
using LanchesEdu.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesEdu.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(x => x.Categoria);
        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(x => x.IsLanchePreferido).Include(x => x.Categoria);
        public Lanche GetLancheById(int id) => _context.Lanches.FirstOrDefault(x => x.IdLanche == x.IdLanche);

    }
}
