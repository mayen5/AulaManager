using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AulaManager.Models
{
    [Table("Grado")]
    public class Grado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un {0}")]
        [StringLength(30, ErrorMessage =
            "El campo {0} debe contener un maximo de {1} y un minimo de {2} caracteres",
            MinimumLength = 3)]
        [Display(Name = "Grado")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar un {0}")]

        public int ProfesorId { get; set; }

        public virtual Profesor Profesor { get; set; }

        public virtual ICollection<AlumnoGrado> AlumnosGrado { get; set; }

    }
}