using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IDLPrueba.Models
{
    /// <summary>
    /// Representa el pais
    /// </summary>
    public class Pais
    {
        public int PaisId { get; set; }
        [Required(ErrorMessage = "Porfavor agrege un Nombre")]
        [Display(Name = "Nombre")]
        public string PaisNombre { get; set; }
        [Required(ErrorMessage = "Porfavor agrege una Descripción")]
        [Display(Name = "Descripción")]
        public string PaisDescripcion { get; set; }

        [Required(ErrorMessage = "Porfavor Indique si el departamento está activo")]
        [Display(Name = "Estado")]
        public int Activo { get; set; }
        public ICollection<Departamento> Departamentos{ get; set; }
    }
}
