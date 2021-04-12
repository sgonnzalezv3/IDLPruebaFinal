using IDLPrueba.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace IDLPrueba.Models.DepartamentoLogic
{

    /// <summary>
    /// Clase encargada de acceder a la base de datos para obtener un departamento que se va a actualiar
    /// </summary>
    public class EditarDepartamento
    {
        /// <value> atributo que realiza comunicación con la clase encargada de la base de datos </value>

        private readonly AppDbContext _context;
        /// <summary>
        /// Constructor encargado de asignar al context el valor el cual tiene la base de datos
        /// </summary>
        /// <param name="context"> contiene el acceso a la base de datos </param>

        public EditarDepartamento(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Metodo encargado de obtener el departamento que se va actualizar 
        /// </summary>
        /// <param name="id">int con el cual se va a obtener el departamento </param>
        /// <returns> departamento que se va actualizar </returns>
        public async Task<Departamento> Edit(int? id)
        {
            if (id == null || id == 0)
                throw new Exception("No se encontró");

            var dep = await _context.Departamento
                .AsSingleQuery()
                .FirstOrDefaultAsync(x => x.DepartamentoId == id);
            if (dep == null)
                throw new Exception("No se encontró");
            return dep;
        }
    }
}
