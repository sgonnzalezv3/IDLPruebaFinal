using IDLPrueba.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace IDLPrueba.Models.CiudadLogic
{
    /// <summary>
    /// Clase encargada de acceder a la base de datos para obtener una ciudad que se va a actualiar
    /// </summary>
    public class EditarCiudad
    {
        /// <value> atributo que realiza comunicación con la clase encargada de la base de datos </value>

        private readonly AppDbContext _context;
        /// <summary>
        /// Constructor encargado de asignar al context el valor el cual tiene la base de datos
        /// </summary>
        /// <param name="context"> contiene el acceso a la base de datos </param>
        public EditarCiudad(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Metodo encargado de obtener la ciudad que se va actualizar 
        /// </summary>
        /// <param name="id">int con el cual se va a obtener la ciudad </param>
        /// <returns> ciudad que se va actualizar </returns>
        public async Task<Ciudad> Edit(int? id)
        {
            if (id == null || id == 0)
                throw new Exception("No se encontró");

            var ciudad = await _context.Ciudad
                .Include(x => x.Departamento)
                .AsSingleQuery()
                .FirstOrDefaultAsync(x => x.CiudadId == id);
            if (ciudad == null)
                throw new Exception("No se encontró");
            return ciudad;
        }
    }
}
