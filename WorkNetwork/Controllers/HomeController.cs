namespace WorkNetwork.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            
            //EN BASE A ESE ID BUSCAMOS EN LA TABLA DE RELACION USUARRIO-ROL QUE REGISTRO TIENE
            var rolUsuario = _context.UserRoles.Where(u => u.UserId == usuarioActual).FirstOrDefault();
            //EN BASE A ESA VARIABLE RECURRIMOS AL ID DEL ROL PARA BUSCAR EN LA TABLA ROL, EL NOMBRE
            var rolNombre = _context.Roles.Where(u => u.Id == rolUsuario.RoleId).Select(r=>r.Name).FirstOrDefault();
            if(rolNombre is "Empresa"){

                var empresaUsuario = (from e in _context.EmpresaUsuarios where e.UsuarioID == usuarioActual select e).Count();
                if (empresaUsuario is 0)
                    return RedirectToAction("Index","Empresas");
                
            }

            var personaMostrar = new PersonaMostrar();
            if (rolNombre is "Usuario"){

                var personaUsuarioCount = (from p in _context.PersonaUsuarios where p.UsuarioID == usuarioActual select p).Count();
                if(personaUsuarioCount == 0){
                    return RedirectToAction("NewPerson","Personas");
                }
                var personaActual = _context.PersonaUsuarios.Where(u => u.UsuarioID == usuarioActual).FirstOrDefault();
                var persona = _context.Persona.Where(u => u.PersonaID == personaActual.PersonaID).FirstOrDefault();
                personaMostrar.NombrePersona = persona.NombrePersona;
                personaMostrar.ImagenPersona = persona.Imagen;
                personaMostrar.TipoImagen = persona.TipoImagen;
                personaMostrar.Imagen = Convert.ToBase64String(persona.Imagen);
            }
            

            //var empresaActual = _context.EmpresaUsuarios.Where(u => u.EmpresaID == usuarioActual).FirstOrDefault();
            ViewData["persona"] = personaMostrar;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}