using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AulaWebDev.Dominio.DTOs;
using AulaWebDev.Dominio.Validacoes;
using AulaWebDev.Dominio.Repositorios;
using AulaWebDev.Dominio.Entidades;
using AutoMapper;

namespace AulaWebDev.Aplicacao.Services
{
    public class CategoriaService: ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<ResultService> AlterarAsync(CategoriaDto categoriaDto)
        {
            if (categoriaDto.Id == Guid.Empty)
                return ResultService.Fail<CategoriaDto>("ID precisa ser informado");

            var result = await new CategoriaDtoValidator().ValidateAsync(categoriaDto);
            if (!result.IsValid)
                return ResultService.RequestError<CategoriaDto>("Um ou mais erros foram encontrados", result);

            var categoria = await _categoriaRepository.ObterCategoriaPorIdAsync(categoriaDto.Id);
            if (categoria == null)
                return ResultService.Fail("Categoria não encontrada!");

            //Mapeando propriedades informadas para edição, na entidade ja existente no banco!
            var categoriaAtualizada = _mapper.Map(categoriaDto, categoria);

            if (await _categoriaRepository.EditarAsync(categoriaAtualizada))
                return ResultService.Ok("Categoria editada com sucesso");

            return ResultService.Fail("Ocorreu um erro ao editar o Categoria");
        }

        public async Task<ResultService<CategoriaDto>> CriarAsync(CategoriaDto categoriaDto)
        {
            if (categoriaDto == null)
                return ResultService.Fail<CategoriaDto>("Objeto nao pode ser nulo");

            var result = await new CategoriaDtoValidator().ValidateAsync(categoriaDto);
            if (!result.IsValid)
                return ResultService.RequestError<CategoriaDto>("Um ou mais erros foram encontrados", result);

            var categoriaPersistida = await _categoriaRepository.CriarAsync(_mapper.Map<Categoria>(categoriaDto));
            var categoriaDtoPersistida = _mapper.Map<CategoriaDto>(categoriaPersistida);

            return ResultService.Ok(categoriaDtoPersistida);
        }

        public async Task<ResultService> DeletarAsync(Guid categoriaId)
        {
            if (categoriaId == Guid.Empty)
                return ResultService.Fail<CategoriaDto>("Id do categoria deve ser informado");

            var categoria = await _categoriaRepository.ObterCategoriaPorIdAsync(categoriaId);
            if (categoria == null)
                return ResultService.Fail("Categoria não encontrada");

            if (await _categoriaRepository.DeletarAsync(categoria))
                return ResultService.Ok("Categoria removida com sucesso");

            return ResultService.Fail("Ocorreu um erro ao remover Categoria");
        }

        public async Task<ResultService<CategoriaDto>> ObterPorIdAsync(Guid categoriaId)
        {
            if (categoriaId == Guid.Empty)
                return ResultService.Fail<CategoriaDto>("Id da categoria deve ser informado");

            var categoria = await _categoriaRepository.ObterCategoriaPorIdAsync(categoriaId);
            if (categoria == null)
                return ResultService.Fail<CategoriaDto>("Categoria não encontrada");

            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);

            return ResultService.Ok(categoriaDto);
        }

        public async Task<ResultService<ICollection<CategoriaDto>>> ObterTodosAsync()
        {
            var categorias = await _categoriaRepository.ObterTodasCategoriasAsync();
            var categoriasMapeadas = _mapper.Map<ICollection<CategoriaDto>>(categorias);
            return ResultService.Ok(categoriasMapeadas);
        }
    }
}
