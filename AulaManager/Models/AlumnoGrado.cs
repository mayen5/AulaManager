using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AulaManager.Models
{
    [Table("AlumnoGrado")]
    public class AlumnoGrado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un {0}")]
        public int AlumnoId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un {0}")]
        public int GradoId { get; set; }

        [Required(ErrorMessage = "Debe ingresar una {0}")]
        [StringLength(1, ErrorMessage =
            "El campo {0} debe contener un maximo de {1} y un minimo de {2} caracteres",
            MinimumLength = 1)]
        [Display(Name = "Sección")]
        public String Seccion { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Grado Grado { get; set; }
    }
}