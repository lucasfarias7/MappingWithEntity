using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace _01052020Entity.Entidades
{
    [Table("dbo.Produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = @"Informe o {0}"), MaxLength(200), MinLength(3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = @"Informe o {0}"), Range(-999999.99, 99999.99)]
        public decimal Preco { get; set; }

        [ForeignKey("Marca")]
        public int IdMarca { get; set; }

        public virtual Marca Marca { get; set; }

    }
}
