using System;
using System.ComponentModel.DataAnnotations;

namespace IDLPrueba.Models
{
    /// <summary>
    /// Representa la ciudad
    /// </summary>
    public class Ciudad
    {
        public int CiudadId { get; set; }
        [Required(ErrorMessage = "Porfavor agrege un nombre")]
        [Display(Name ="Nombre")]
        public string CiudadNombre { get; set; }
        [Required(ErrorMessage = "Porfavor agrege una descripción")]
        [Display(Name = "Descripción")]
        public string CiudadDescripcion { get; set; }
        [Required(ErrorMessage = "Porfavor Seleccione un departamento")]
        [Display(Name ="Departamento perteneciente")]
        public int DepartamentoId { get; set; }
        [Required(ErrorMessage = "Porfavor agrege un estado de la ciudad")]
        [Display(Name ="Estado")]
        public int Activo { get; set; }
        [Required(ErrorMessage = "Porfavor agrege la fecha de la ciudad")]
        [Display(Name ="Fecha de creación")]
        public DateTime FCreacion { get; set; }
        [Display(Name = "Fecha de modificación")]
        public DateTime FModificacion { get; set; }
        [Display(Name = "Identificación del usuario")]
        [Required(ErrorMessage = "Porfavor agrege el código del usuario")]
        public int Usuario { get; set; }
        public Departamento Departamento { get; set; }
    }
}
