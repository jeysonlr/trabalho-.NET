using AulaWebDev.Dominio.Entidades;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AulaWebDev.Infra.Repositorios
{
    public class CategoriaRepository: ICategoriaRepository
    {
        private readonly AulaWebDevDbContext _dbContext;
        private readonly ILogger<CategoriaRepository> _logger;

        public CategoriaRepository(AulaWebDevDbContext dbContext, ILogger<CategoriaRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Categoria> CriarAsync(Categoria categoria)
        {
            try
            {
                _dbContext.Add(categoria);
                await _dbContext.SaveChangesAsync();
                return categoria;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return categoria;
            }
        }

        public async Task<bool> DeletarAsync(Categoria categoria)
        {
            try
            {
                _dbContext.Remove(categoria);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> EditarAsync(Categoria categoria)
        {
            try
            {
                _dbContext.Update(categoria);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Categoria?> ObterCategoriaPorIdAsync(Guid categoriaId)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == categoriaId);
        }

        public async Task<Categoria?> ObterCategoriaPorCodCategoryAsync(int codCategory)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.CodCategoria == codCategory);
        }

        public async Task<ICollection<Categoria>> ObterTodasCategoriasAsync()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
    }
}
