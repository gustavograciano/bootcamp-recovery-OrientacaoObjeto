using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEF.Models
{
    [Table("TB_BLOG")]
    class Blog
    {
        [Key]
        [Column("ID_BLOG")]
        public int Id { get; set; }
        
        [Column("DSC_BLOG", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }
        [Column("DT_CREATED")]
        public DateTime CreatedTimestamp { get; set; }

        public virtual ICollection<BlogUser> BlogsUser { get; set; }
    }
}
