using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IDLPrueba.Models
{
    /// <summary>
    /// Representa el departamento
    /// </summary>
    public class Departamento
    {

        public int DepartamentoId { get; set; }
        [Required(ErrorMessage = "Porfavor agrege un Nombre")]
        [Display(Name = "Nombre")]
        public string DepartamentoNombre { get; set; }
        [Required(ErrorMessage = "Porfavor agrege una Descripción")]
        [Display(Name = "Descripción")]
        public string DepartamentoDescripcion { get; set; }
        [Required(ErrorMessage = "Porfavor agrege El código del pais perteneciente")]
        [Display(Name = "Pais Pertenenciente")]
        public int PaisId { get; set; }
        [Required(ErrorMessage = "Porfavor Indique si el departamento está activo")]
        [Display(Name = "Estado")]
        public int Activo { get; set; }
        [Required(ErrorMessage = "Porfavor agrege la fecha de creación")]
        [Display(Name = "Fecha de creación")]
        public DateTime FCreacion { get; set; }
        [Required(ErrorMessage = "Porfavor agrege el usuario")]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Porfavor agregue la fecha de Modificación")]
        [Display(Name = "Fecha de Modificación")]
        public DateTime FModificacion { get; set; }
        public ICollection<Ciudad> Ciudades { get; set; }
        public Pais pais { get; set; }
    }
}
