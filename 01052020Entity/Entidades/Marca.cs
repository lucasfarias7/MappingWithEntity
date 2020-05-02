using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _01052020Entity.Entidades
{
    [Table("dbo.Marcas")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(200), MinLength(3)]
        public string Nome { get; set; }

        public virtual ICollection<Produto> produtos { get; set; }

    }
}
