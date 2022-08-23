using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebDev.Dominio.DTOs
{
    public class ProdutoResponseDto
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string? Descricao { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal Valor { get; set; }
        public CategoriaDto Categoria { get; set; }
    }
}
