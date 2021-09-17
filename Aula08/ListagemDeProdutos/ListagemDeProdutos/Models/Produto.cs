using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListagemDeProdutos.Models
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataValidade { get; set; }
        public decimal Valor { get; set; }
    }
}
