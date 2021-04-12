using IDLPrueba.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDLPrueba.Models.DepartamentoLogic
{
    /// <summary>
    /// Servicio que permite realizar busqueda de los departamentos en la base de datos
    /// </summary>
    public class ConsultarDepartamentoLista
    {
        /// <value> atributo que realiza comunicación con la clase encargada de la base de datos </value>
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor encargado de asignar al context el valor el cual tiene la base de datos
        /// </summary>
        /// <param name="context"> contiene el acceso a la base de datos </param>
        public ConsultarDepartamentoLista(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Metodo encargado de obtener la lista de Departamentos 
        /// </summary>
        /// <param name="search">string el cual se va utilizar como filtro al momento de obtener la data</param>
        /// <returns> lista de departamentos </returns>
        public async Task<List<Departamento>> ListaCiudades(string search)
        {
            List<Departamento> departamentos = await _context.Departamento
                .Include(x => x.Ciudades)
                .AsSingleQuery()
                .ToListAsync();

            if (!String.IsNullOrEmpty(search))
            {
        /// <value> Query que busca obtener las ciudades que contengan el string search en su atributo CiudadNombre </value>

                IQueryable<Departamento> FiltroBusqueda = from data in _context.Departamento
                                                    where data.DepartamentoNombre.Contains(search)
                                                    select data;
                departamentos = FiltroBusqueda.ToList();
            }
            return departamentos;
        }
    }
}
