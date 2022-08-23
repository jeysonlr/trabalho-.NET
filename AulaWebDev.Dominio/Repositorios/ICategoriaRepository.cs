using AulaWebDev.Dominio.Entidades;

namespace AulaWebDev.Dominio.Repositorios
{
    public interface ICategoriaRepository
    {
        Task<Categoria> CriarAsync(Categoria categoria);
        Task<bool> DeletarAsync(Categoria categoria);
        Task<bool> EditarAsync(Categoria categoria);
        Task<Categoria?> ObterCategoriaPorIdAsync(Guid categoriaId);
        Task<Categoria?> ObterCategoriaPorCodCategoryAsync(int codCategory);
        Task<ICollection<Categoria>> ObterTodasCategoriasAsync();

    }
}
