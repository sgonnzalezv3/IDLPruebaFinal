using IDLPrueba.Models;
using IDLPrueba.Models.DepartamentoLogic;
using IDLPrueba.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IDLPrueba.Controllers
{
    /// <summary>
    /// Responde a eventos y realiaza peticiones de todo lo que respecta a la clase Departamento
    /// </summary>
    public class DepartamentosController : Controller
    {
        /// <value> propiedad de la clase encargada de hacer llamado a la base de datos por medio del AppDbContext </value>
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor donde se obtiene la base de datos por medio de inyección de dependencias
        /// </summary>
        /// <param name="context"> Corresponde al llamado a la clase que interactua con la base de datos </param>
        /// 
        public DepartamentosController(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Método encargado de obtener la lista de departamentos de la base de datos y pasarlas a la vista para que esta las pueda ilustrar
        /// </summary>
        /// <param name="search"> Representa el texto con el cual se va a flitrar la busqueda de los departamentos en la caja de busqueda.</param>
        /// <returns>Vista Index con la data de departamentos</returns>
        public async Task<IActionResult> Index(string search)
        {
            /// <value> Propiedad encargada de comunicar la data de Search con la vista </value>
            ViewData["Filtro"] = search;
            /// <value> instancia que permite consultar los departamentos en la base de datos </value>
            ConsultarDepartamentoLista departamentos = new ConsultarDepartamentoLista(_context);
            return View(await departamentos.ListaCiudades(search));
        }
        /// <summary>
        /// Mátodo encargado de direccionar a la vista Create, en donde se llena la información para crear un nuevo departamento
        /// </summary>
        /// <returns>Vista Create, la cual es un formulario para crear un nuevo departamento </returns>
        public async Task<IActionResult> Create()
        {
            /// <value> lista de departamentos obtenidos de la bd </value>
            List<Pais> paises = await _context.Pais.ToListAsync();
            /// <value> propiedad encargada de comunicar a la vista la información de departamentos </value>
            ViewData["paises"] = paises;
            return View();
        }
        /// <summary>
        /// Método que se encarga de almacenar el departamento ingresado en la base de datos. 
        /// </summary>
        /// <param name="departamento">data del departamento que sera almacenada en la base datos</param>
        /// <returns>retorna la vista principal con mensaje notificando la acción exitosa </returns>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Departamento.Add(departamento);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Se ha creado el departamento correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        /// <summary>
        /// metodo encargado de ilustrar la vista con la información de el departamento que se va a actualizar dada Id
        /// </summary>
        /// <param name="id">Representa el id de el departamento que se va a actualizar</param>
        /// <returns> vista la cual tendrá como parametro el departamento que se va actualizar</returns>

        public async Task<IActionResult> Edit(int? id)
        {
            /// <value> Propiedad encargada de obtener el departamento que se va a editar</value>
            EditarDepartamento dep = new EditarDepartamento(_context);
            return View(await dep.Edit(id));
        }
        /// <summary>
        /// Método que dirige a la vista de editar un departamento, permitiendo alterar la información de un departamento existente
        /// </summary>
        /// <param name="departamento"> representa el departamento el cual se va a editar </param>
        /// <returns> retorna a la vista principal, con un mensaje de satisfacción</returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _context.Departamento.Update(departamento);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Se ha Actualizado el departamento correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// metodo encargado de ilustrar la vista con la información de el departamento que se va eliminar dada Id
        /// </summary>
        /// <param name="id">Representa el id de el departamento que se va eliminar</param>
        /// <returns> vista la cual tendrá como parametro el departamento que se va eliminar</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            /// <value> parametro encargado de obtener la ciudad a eliminar  </value>
            EliminarDepartamento departamento = new EliminarDepartamento(_context);
            return View(await departamento.Eliminar(id));
        }

        /// <summary>
        /// Método encargado de comunicar a la base de datos la eliminación de un departamento
        /// </summary>
        /// <param name="DepartamentoId">representa el Id de el departamento, el cual sera de referencia para la eliminación</param>
        /// <returns>Regresa a la vista Index, con un mensaje de satisfacción</returns>

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteDep(int? DepartamentoId)
        {
            var departamento = await _context.Departamento.FindAsync(DepartamentoId);
            if(departamento == null)
                return NotFound();
            _context.Departamento.Remove(departamento);
            await _context.SaveChangesAsync();
            TempData["mensaje"] = "Se ha eliminado el departamento correctamente";
            return RedirectToAction("Index");
        }
    }
}
