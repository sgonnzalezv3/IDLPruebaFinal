using IDLPrueba.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDLPrueba.Models.CiudadLogic
{
    /// <summary>
    /// Servicio que permite realizar busqueda de las ciudades en la base de datos
    /// </summary>
    public class ConsultarCiudadLista
    {
        /// <value> atributo que realiza comunicación con la clase encargada de la base de datos </value>
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor encargado de asignar al context el valor el cual tiene la base de datos
        /// </summary>
        /// <param name="context"> contiene el acceso a la base de datos </param>
        public ConsultarCiudadLista(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Metodo encargado de obtener la lista de ciudades 
        /// </summary>
        /// <param name="search">string el cual se va utilizar como filtro al momento de obtener la data</param>
        /// <returns> lista de ciudades </returns>
        public async Task<List<Ciudad>> ListaCiudades(string search)
        {
            List<Ciudad> ciudades = await _context.Ciudad
                .Include(x => x.Departamento)
                .AsSingleQuery()
                .ToListAsync();
            if (!String.IsNullOrEmpty(search))
            {
        /// <value> Query que busca obtener las ciudades que contengan el string search en su atributo CiudadNombre </value>

                IQueryable<Ciudad> FiltroBusqueda = from data in _context.Ciudad
                                                    where data.CiudadNombre.Contains(search)
                                                    select data;
                ciudades = FiltroBusqueda.ToList();
            }
            return ciudades;
        }
    }
}
