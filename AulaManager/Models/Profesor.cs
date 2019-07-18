using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AulaManager.Models
{
    [Table("Profesor")]
    public class Profesor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar un {0}")]
        [StringLength(30, ErrorMessage =
            "El campo {0} debe contener un maximo de {1} y un minimo de {2} caracteres",
            MinimumLength = 3)]
        [Display(Name = "Nombres")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar los {0}")]
        [StringLength(30, ErrorMessage =
            "El campo {0} debe contener un maximo de {1} y un minimo de {2} caracteres",
            MinimumLength = 3)]
        [Display(Name = "Apellidos")]
        public String Apellidos { get; set; }

        [Required(ErrorMessage = "Debe ingresar un {0}")]
        [StringLength(1, ErrorMessage =
            "El campo {0} debe contener un maximo de {1} y un minimo de {2} caracteres",
            MinimumLength = 1)]
        [Display(Name = "Genero")]
        public String Genero { get; set; }

        [Display(Name = "Nombre Completo")]
        public virtual String NombreCompleto { get { return String.Format("{0} {1}", this.Nombre, this.Apellidos); } }

        public virtual ICollection<Grado> Grados { get; set; }
    }
}