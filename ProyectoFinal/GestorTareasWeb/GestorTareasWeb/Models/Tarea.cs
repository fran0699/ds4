using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GestorTareasWeb.Models
{
    public class Tarea
    {
        public int IdTarea { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Fecha de vencimiento")]
        [DataType(DataType.Date)]
        public DateTime? FechaVencimiento { get; set; }

        [Display(Name = "¿Completada?")]
        public bool EstaCompletada { get; set; }
    }
}