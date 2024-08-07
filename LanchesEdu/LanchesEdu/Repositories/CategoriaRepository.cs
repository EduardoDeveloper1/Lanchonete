﻿using LanchesEdu.Context;
using LanchesEdu.Models;
using LanchesEdu.Repositories.Interfaces;

namespace LanchesEdu.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
