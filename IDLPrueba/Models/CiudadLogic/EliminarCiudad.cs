using IDLPrueba.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace IDLPrueba.Models.CiudadLogic
{

    /// <summary>
    /// Clase encargada de acceder a la base de datos para obtener una ciudad que se va a eliminar
    /// </summary>
    public class EliminarCiudad
    {
        /// <value> atributo que realiza comunicación con la clase encargada de la base de datos </value>

        private readonly AppDbContext _context;
        /// <summary>
        /// Constructor encargado de asignar al context el valor el cual tiene la base de datos
        /// </summary>
        /// <param name="context"> contiene el acceso a la base de datos </param>
        public EliminarCiudad(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Metodo encargado de obtener la ciudad que se va eliminar 
        /// </summary>
        /// <param name="id">int con el cual se va a obtener la ciudad </param>
        /// <returns> ciudad que se va eliminar </returns>
        public async Task<Ciudad> Eliminar(int? id)
        {
            if (id == null || id == 0)
                throw new Exception("Error");
            var ciudad = await _context.Ciudad
                .Include(x => x.Departamento)
                .FirstOrDefaultAsync(x => x.CiudadId == id);
            if (ciudad == null)
                throw new Exception("Error");
            return ciudad;
        }
    }
}
