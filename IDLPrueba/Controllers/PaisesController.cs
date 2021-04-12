using IDLPrueba.Models;
using IDLPrueba.Models.PaisLogic;
using IDLPrueba.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IDLPrueba.Controllers
{

    /// <summary>
    /// Responde a eventos y realiaza peticiones de todo lo que respecta a la clase Pais
    /// </summary>
    public class PaisesController : Controller
    {
        /// <value> propiedad de la clase encargada de hacer llamado a la base de datos por medio del AppDbContext </value>
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor donde se obtiene la base de datos por medio de inyección de dependencias
        /// </summary>
        /// <param name="context"> Corresponde al llamado a la clase que interactua con la base de datos </param>
        /// 
        public PaisesController(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Método encargado de obtener la lista de paises de la base de datos y pasarlas a la vista para que esta las pueda ilustrar
        /// </summary>
        /// <param name="search"> Representa el texto con el cual se va a flitrar la busqueda de los paises en la caja de busqueda.</param>
        /// <returns>Vista Index con la data de paises</returns>
        public async Task<IActionResult> Index(string search)
        {
            /// <value> Propiedad encargada de comunicar la data de Search con la vista </value>
            ViewData["Filtro"] = search;
            /// <value> instancia que permite consultar los paises en la base de datos </value>
            ConsultarPaisLista paises = new ConsultarPaisLista(_context);
            return View(await paises.ListaPaises(search));
        }
        /// <summary>
        /// Mátodo encargado de direccionar a la vista Create, en donde se llena la información para crear un nuevo pais
        /// </summary>
        /// <returns>Vista Create, la cual es un formulario para crear un nuevo pais </returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Método que se encarga de almacenar el pais ingresado en la base de datos. 
        /// </summary>
        /// <param name="pais">data del pais que sera almacenada en la base datos</param>
        /// <returns>retorna la vista principal con mensaje notificando la acción exitosa </returns>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Pais pais)
        {
            if (ModelState.IsValid)
            {
                _context.Pais.Add(pais);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Se ha creado el pais correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        /// <summary>
        /// metodo encargado de ilustrar la vista con la información de el pais que se va a actualizar dada Id
        /// </summary>
        /// <param name="id">Representa el id de el pais que se va a actualizar</param>
        /// <returns> vista la cual tendrá como parametro el pais que se va actualizar</returns>

        public async Task<IActionResult> Edit(int? id)
        {
            /// <value> Propiedad encargada de obtener el pais que se va a editar</value>
            EditarPais pais = new EditarPais(_context);
            return View(await pais.Edit(id));
        }
        /// <summary>
        /// Método que dirige a la vista de editar un pais, permitiendo alterar la información de un pais existente
        /// </summary>
        /// <param name="pais"> representa el pais el cual se va a editar </param>
        /// <returns> retorna a la vista principal, con un mensaje de satisfacción</returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Pais pais)
        {
            if (ModelState.IsValid)
            {
                _context.Pais.Update(pais);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Se ha Actualizado el pais correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// metodo encargado de ilustrar la vista con la información de el pais que se va eliminar dada Id
        /// </summary>
        /// <param name="id">Representa el id de el pais que se va eliminar</param>
        /// <returns> vista la cual tendrá como parametro el pais que se va eliminar</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            /// <value> parametro encargado de obtener el pais a eliminar  </value>
            EliminarPais pais = new EliminarPais(_context);
            return View(await pais.Eliminar(id));
        }

        /// <summary>
        /// Método encargado de comunicar a la base de datos la eliminación de un pais
        /// </summary>
        /// <param name="paisId">representa el Id de el pais, el cual sera de referencia para la eliminación</param>
        /// <returns>Regresa a la vista Index, con un mensaje de satisfacción</returns>

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeletePa(int? paisId)
        {
            var pais = await _context.Pais.FindAsync(paisId);
            if (pais == null)
                return NotFound();
            _context.Pais.Remove(pais);
            await _context.SaveChangesAsync();
            TempData["mensaje"] = "Se ha eliminado el pais correctamente";
            return RedirectToAction("Index");
        }
    }
}
