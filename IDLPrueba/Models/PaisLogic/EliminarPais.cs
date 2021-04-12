using IDLPrueba.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDLPrueba.Models.PaisLogic
{
    /// <summary>
    /// Clase encargada de acceder a la base de datos para obtener un pais que se va a eliminar
    /// </summary>
    public class EliminarPais
    {
        /// <value> atributo que realiza comunicación con la clase encargada de la base de datos </value>

        private readonly AppDbContext _context;
        /// <summary>
        /// Constructor encargado de asignar al context el valor el cual tiene la base de datos
        /// </summary>
        /// <param name="context"> contiene el acceso a la base de datos </param>
        public EliminarPais(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Metodo encargado de obtener el pais que se va eliminar 
        /// </summary>
        /// <param name="id">int con el cual se va a obtener el pais </param>
        /// <returns> pais que se va eliminar </returns>
        public async Task<Pais> Eliminar(int? id)
        {
            if (id == null || id == 0)
                throw new Exception("Error");
            var pais = await _context.Pais
                .FirstOrDefaultAsync(x => x.PaisId == id);
            if (pais == null)
                throw new Exception("Error");
            return pais;
        }
    }
}
