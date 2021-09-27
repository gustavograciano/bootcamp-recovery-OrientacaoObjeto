using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMercadoMVC.Models
{
    [Table("TB_VENDA_ITEM")]
    public class VendaItem
    {
        [Key]
        [Column("ID_VENDA_ITEM")]
        public int Id { get; set; }

        [Column("ID_PRODUTO")]
        public int IdProduto { get; set; }

        [Column("ID_VENDA")]
        public int IdVenda { get; set; }

        [Column("QTD_VENDA")]
        public int Quantidade { get; set; }

        [ForeignKey("IdVenda")]
        public Venda Venda { get; set; }

        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }
    }
}
