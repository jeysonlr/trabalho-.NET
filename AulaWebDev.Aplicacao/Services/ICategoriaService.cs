﻿using AulaWebDev.Dominio.DTOs;

namespace AulaWebDev.Aplicacao.Services
{
    public interface ICategoriaService
    {
        Task<ResultService<CategoriaDto>> CriarAsync(CategoriaDto categoriaDto);
        Task<ResultService> AlterarAsync(CategoriaDto categoriaDto);
        Task<ResultService<CategoriaDto>> ObterPorIdAsync(Guid categoriaId);
        Task<ResultService<ICollection<CategoriaDto>>> ObterTodosAsync();
        Task<ResultService> DeletarAsync(Guid categoriaId);
    }
}
