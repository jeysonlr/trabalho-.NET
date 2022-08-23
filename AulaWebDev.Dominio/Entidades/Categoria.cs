using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebDev.Dominio.Entidades
{
    public class Categoria
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int CodCategoria { get; private set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria(Guid id, string nome, int codCategoria)
        {
            Id = id;
            Nome = nome;
            CodCategoria = codCategoria;
        }

        public Categoria(string nome, int codCategoria)
        {
            Nome = nome;
            CodCategoria= codCategoria;
        }
    }
}
