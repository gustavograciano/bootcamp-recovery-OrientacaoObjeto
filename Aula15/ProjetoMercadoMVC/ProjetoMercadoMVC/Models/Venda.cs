using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMercadoMVC.Models
{
    [Table("TB_VENDA")]
    public class Venda
    {
        [Key]
        [Column("ID_VENDA")]
        public int Id { get; set; }

        [Column("ID_USUARIO_VENDA")]
        public int IdUsuario { get; set; }

        [Column("VLR_TOTAL_VENDA", TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario  Usuario { get; private set; }

        public virtual ICollection<VendaItem> Itens { get; private set; }
    }
}
