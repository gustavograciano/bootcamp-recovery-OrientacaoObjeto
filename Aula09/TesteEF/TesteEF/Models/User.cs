using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEF.Models
{
    [Table("TB_USER")]
    class User
    {
        [Key]
        [Column("ID_USER")]
        public int Id { get; set; }
        [Column("NM_USER", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        public virtual ICollection<Blog> Blogs {get; set;}
    }
}
