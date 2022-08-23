using AulaWebDev.Dominio.DTOs;
using FluentValidation;

namespace AulaWebDev.Dominio.Validacoes
{
    public class CategoriaDtoValidator : AbstractValidator<CategoriaDto>
    {
        public CategoriaDtoValidator()
        {
            ValidarNome();
            ValidarCodCategory();
        }

        private void ValidarNome()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome precisa ser informado!");
        }

        private void ValidarCodCategory()
        {
            RuleFor(x => x.CodCategoria)
                .NotNull()
                .NotEmpty()
                .WithMessage("CodCategoria deve ser informado!");
        }
    }
}
