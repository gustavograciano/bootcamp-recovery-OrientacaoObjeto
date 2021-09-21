using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEF.Models
{
    [Table("TB_BLOG_USER")]
    class BlogUser
    {
        [Key]
        [Column("ID_BLOG_USER")]
        public int Id { get; set; }

        [Column("ID_USER")]
        public int IdUser { get; set; }

        [Column("ID_BLOG")]
        public int IdBlog { get; set; }

        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

        [ForeignKey("IdBlog")]
        public virtual Blog Blog { get; set; }
    }
}
