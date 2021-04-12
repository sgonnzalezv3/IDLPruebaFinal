using IDLPrueba.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDLPrueba.Models.DepartamentoLogic
{
    /// <summary>
    /// Clase encargada de acceder a la base de datos para obtener una ciudad que se va a eliminar
    /// </summary>
    public class EliminarDepartamento
    {
        /// <value> atributo que realiza comunicación con la clase encargada de la base de datos </value>

        private readonly AppDbContext _context;
        /// <summary>
        /// Constructor encargado de asignar al context el valor el cual tiene la base de datos
        /// </summary>
        /// <param name="context"> contiene el acceso a la base de datos </param>
        public EliminarDepartamento(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Metodo encargado de obtener el departamento que se va eliminar 
        /// </summary>
        /// <param name="id">int con el cual se va a obtener el departamento </param>
        /// <returns> departamento que se va eliminar </returns>
        public async Task<Departamento> Eliminar(int? id)
        {
            if (id == null || id == 0)
                throw new Exception("Error");
            var dep = await _context.Departamento
                .FirstOrDefaultAsync(x => x.DepartamentoId == id);
            if (dep == null)
                throw new Exception("Error");
            return dep;
        }
    }
}
