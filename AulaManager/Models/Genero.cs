using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AulaManager.Models
{
    [Table("Genero")]
    public class Genero
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un {0}")]
        [StringLength(1, ErrorMessage =
            "El campo {0} debe contener un maximo de {1} y un minimo de {2} caracteres",
            MinimumLength = 1)]
        [Display(Name = "Genero")]
        public String Descripcion { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }

    }
}