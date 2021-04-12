using IDLPrueba.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDLPrueba.Models.PaisLogic
{
    /// <summary>
    /// Servicio que permite realizar busqueda de los paises en la base de datos
    /// </summary>
    public class ConsultarPaisLista
    {
        /// <value> atributo que realiza comunicación con la clase encargada de la base de datos </value>
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor encargado de asignar al context el valor el cual tiene la base de datos
        /// </summary>
        /// <param name="context"> contiene el acceso a la base de datos </param>
        public ConsultarPaisLista(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Metodo encargado de obtener la lista de paises 
        /// </summary>
        /// <param name="search">string el cual se va utilizar como filtro al momento de obtener la data</param>
        /// <returns> lista de paises </returns>
        public async Task<List<Pais>> ListaPaises(string search)
        {
            List<Pais> paises = await _context.Pais
                .Include(x => x.Departamentos)
                .AsSingleQuery()
                .ToListAsync();

            if (!String.IsNullOrEmpty(search))
            {
                /// <value> Query que busca obtener los paises que contengan el string search en su atributo PaisNombre </value>

                IQueryable<Pais> FiltroBusqueda = from data in _context.Pais
                                                          where data.PaisNombre.Contains(search)
                                                          select data;
                paises = FiltroBusqueda.ToList();
            }
            return paises;
        }
    }
}
