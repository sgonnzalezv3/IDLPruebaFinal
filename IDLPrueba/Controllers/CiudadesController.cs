using IDLPrueba.Models;
using IDLPrueba.Models.CiudadLogic;
using IDLPrueba.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDLPrueba.Controllers
{

    /// <summary>
    /// Responde a eventos y realiaza peticiones de todo lo que respecta a la clase Ciudad
    /// </summary>
    public class CiudadesController : Controller
    {
        /// <value> propiedad de la clase encargada de hacer llamado a la base de datos por medio del AppDbContext </value>
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor donde se obtiene la base de datos por medio de inyección de dependencias
        /// </summary>
        /// <param name="context"> Corresponde al llamado a la clase que interactua con la base de datos </param>
        /// 
        public CiudadesController(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Método encargado de obtener la lista de ciudades de la base de datos y pasarlas a la vista para que esta las pueda ilustrar
        /// </summary>
        /// <param name="search"> Representa el texto con el cual se va a flitrar la busqueda de las ciudades en la caja de busqueda.</param>
        /// <returns>Vista Index con la data de ciudades</returns>
        public async Task<IActionResult> Index(string search)
        {
            /// <value> Propiedad encargada de comunicar la data de Search con la vista </value>
            ViewData["Filtro"] = search;
            /// <value> instancia que permite consultar las ciudades en la base de datos </value>
            ConsultarCiudadLista ciudades = new ConsultarCiudadLista(_context);
            return View( await ciudades.ListaCiudades(search));
        }
        /// <summary>
        /// Mátodo encargado de direccionar a la vista Create, en donde se llena la información para crear una nueva Ciudad
        /// </summary>
        /// <returns>Vista Create, la cual es un formulario para crear una nueva ciudad </returns>

        public async Task<IActionResult> Create()
        {
            /// <value> lista de departamentos obtenidos de la bd </value>
            List<Departamento> departamentos = await _context.Departamento.ToListAsync();
            /// <value> propiedad encargada de comunicar a la vista la información de departamentos </value>
            ViewData["departamentos"] = departamentos;
            return View();
        }

        /// <summary>
        /// Método que se encarga de almacenar la ciudad ingresada en la base de datos. 
        /// </summary>
        /// <param name="ciudad"> data de la ciudad que sera almacenada en la base de datos </param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ciudad ciudad)
        {

            if (ModelState.IsValid)
            {
                _context.Ciudad.Add(ciudad);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Se ha creado la ciudad correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// metodo encargado de ilustrar la vista con la información de la ciudad que se va eliminar dada Id
        /// </summary>
        /// <param name="id">Representa el id de la ciudad que se va eliminar</param>
        /// <returns> vista la cual tendrá como parametro la ciudad que se va eliminar</returns>

        public async Task<IActionResult> Delete(int? id)
        {
         /// <value> parametro encargado de obtener la ciudad a eliminar  </value>
            EliminarCiudad ciudad = new EliminarCiudad(_context);
             return View(await ciudad.Eliminar(id));
        }
        
        /// <summary>
        /// Método encargado de comunicar a la base de datos la eliminación de la ciudad
        /// </summary>
        /// <param name="CiudadId">representa el Id de la ciudad, el cual sera de referencia para la eliminación</param>
        /// <returns>Regresa a la vista Index, con un mensaje de satisfacción</returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCiudad(int? CiudadId)
        {
            var ciudad = await _context.Ciudad.FindAsync(CiudadId);
            if (ciudad == null)
                return NotFound();
            _context.Ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();
            TempData["mensaje"] = "Se ha eliminado La ciudad correctamente";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Método que dirige a la vista de editar una ciudad, permitiendo alterar la información de una ciudad existente
        /// </summary>
        /// <param name="ciudad"> representa la ciudad la cual se va a editar </param>
        /// <returns> retorna a la vista principal, con un mensaje de satisfacción</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                _context.Ciudad.Update(ciudad);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Se ha Actualizado la ciudad correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        /// <summary>
        /// Metodo que comunica a la base de datos, con el fin de actualizar la nueva información de la ciudad
        /// </summary>
        /// <param name="id"> hace referencia al id de la ciudad que se ha actualizado </param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
        /// <value> Propiedad encargada de obtener la ciudad que se va a editar</value>
            EditarCiudad ciudad = new EditarCiudad(_context);
            return View(await ciudad.Edit(id));
        }
    }
}
