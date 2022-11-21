namespace WorkNetwork.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public PersonasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            // BUSCO EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);

            var rolUsuario = _context.UserRoles.Where(u => u.UserId == usuarioActual).FirstOrDefault();
            //EN BASE A ESE ID BUSCAMOS EN LA TABLA DE RELACION USUARRIO-ROL QUE REGISTRO TIENE
            var rolNombre = _context.Roles.Where(u => u.Id == rolUsuario.RoleId).Select(r => r.Name).FirstOrDefault();
            //EN BASE AL USUARIO BUSCO EN LA TABLA PARA VER SI ESTA RELACIONADO A ALGUAN PERSONA. 
            if (rolNombre is "Usuario")
            {

                var personaUsuario = (from p in _context.PersonaUsuarios where p.UsuarioID == usuarioActual select p).Count();
                if (personaUsuario == 0)
                {
                    return RedirectToAction("NewPerson", "Personas");
                }
            }
            return View();
        }

        public JsonResult PerfilInfo()
        {
            //BUSCO L USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //BUSCO LA RELACION ENTRE PERSONA USUARIO
            var personaUsuario = _context.PersonaUsuarios.Where(u => u.UsuarioID == usuarioActual).FirstOrDefault();
            //SEGUN EL ID DE LA PERSONA OBTENGO TODA LA COLUMNA
            var persona = _context.Persona.Where(u => u.PersonaID == personaUsuario.PersonaID).FirstOrDefault();
            return Json(persona);
        }

        public IActionResult PerfilUser(int? id)
        {
            var personaMostrar = new PersonaMostrar();
            if (id == null)
            {
                //BUSCO L USUARIO ACTUAL
                var usuarioActual = _userManager.GetUserId(HttpContext.User);
                //BUSCO LA RELACION ENTRE PERSONA USUARIO
                var personaUsuario = _context.PersonaUsuarios.Where(u => u.UsuarioID == usuarioActual).FirstOrDefault();
                //SEGUN EL ID DE LA PERSONA OBTENGO TODA LA COLUMNA
                var persona = _context.Persona.Where(u => u.PersonaID == personaUsuario.PersonaID).FirstOrDefault();
                var correo = _context.Users.Where(u => u.Id == personaUsuario.UsuarioID).Select(c => c.Email).Single();
                var localidadNombre = _context.Localidad.Where(u => u.LocalidadID == persona.LocalidadID).Select(l => l.NombreLocalidad).Single();
                personaMostrar.PersonaID = persona.PersonaID;
                personaMostrar.NombrePersona = persona.NombrePersona;
                personaMostrar.ApellidoPersona = persona.ApellidoPersona;
                personaMostrar.Telefono1 = persona.Telefono1;
                personaMostrar.NumeroDocumento = persona.NumeroDocumento;
                personaMostrar.FechaNacimiento = persona.FechaNacimiento;
                personaMostrar.DomicilioPersona = persona.DomicilioPersona;
                personaMostrar.Instagram = persona.Instagram;
                personaMostrar.Linkedin = persona.Linkedin;
                personaMostrar.Twitter = persona.Twitter;
                personaMostrar.LocalidadNombre = localidadNombre;
                personaMostrar.Correo = correo;
                if (persona.Imagen != null)
                {
                    personaMostrar.ImagenPersona = persona.Imagen;
                    personaMostrar.TipoImagen = persona.TipoImagen;
                    personaMostrar.Imagen = Convert.ToBase64String(persona.Imagen);
                }
                if (persona.Curriculum != null)
                {
                    personaMostrar.Curriculum = persona.Curriculum;
                    personaMostrar.TipoCV = persona.TipoCV;
                    personaMostrar.CurriculumString = Convert.ToBase64String(persona.Curriculum);
                }

                personaMostrar.Eliminado = persona.Eliminado;
            }
            else
            {
                var persona = _context.Persona.Where(u => u.PersonaID == id).FirstOrDefault();
                var localidadNombre = _context.Localidad.Where(u => u.LocalidadID == persona.LocalidadID).Select(l => l.NombreLocalidad);

                personaMostrar.PersonaID = persona.PersonaID;
                personaMostrar.NombrePersona = persona.NombrePersona;
                personaMostrar.ApellidoPersona = persona.ApellidoPersona;
                personaMostrar.NumeroDocumento = persona.NumeroDocumento;
                personaMostrar.FechaNacimiento = persona.FechaNacimiento;
                personaMostrar.DomicilioPersona = persona.DomicilioPersona;
                if (persona.Imagen != null)
                {
                    personaMostrar.ImagenPersona = persona.Imagen;
                    personaMostrar.TipoImagen = persona.TipoImagen;
                    personaMostrar.Imagen = Convert.ToBase64String(persona.Imagen);
                }
                personaMostrar.Eliminado = persona.Eliminado;
            }

            ViewData["persona"] = personaMostrar;
            return View();
        }

        public IActionResult NewPerson()
        {
            var paises = _context.Pais.ToList();
            paises.Add(new Pais { PaisID = 0, NombrePais = "[SELECCIONE UN PAIS]" });
            ViewBag.PaisID = new SelectList(paises.OrderBy(e => e.NombrePais), "PaisID", "NombrePais");

            var provincias = _context.Provincia.ToList();
            provincias.Add(new Provincia { ProvinciaID = 0, NombreProvincia = "[SELECCIONE UN PAIS]" });
            ViewBag.ProvinciaID = new SelectList(provincias.OrderBy(x => x.NombreProvincia), "ProvinciaID", "NombreProvincia");

            var localidad = _context.Localidad.ToList();
            localidad.Add(new Localidad { LocalidadID = 0, NombreLocalidad = "[SELECCIONE UN PAIS]" });
            ViewBag.LocalidadID = new SelectList(localidad.OrderBy(x => x.NombreLocalidad), "LocalidadID", "NombreLocalidad");

            return View();
        }
        public JsonResult TablaPersonas()
        {
            var personas = _context.Persona.ToList();
            return Json(personas);
        }


        //--------------------PARAMETROS DEL GUARDAR PERSONA ---------------------------
        //Metodo para limpiar el numero telefonico
        static string ClearNumber(string numero) => new string((numero ?? "").Where(c => c == '+' || char.IsNumber(c)).ToArray());
        public JsonResult GuardarPersona(int IdPersona, string nombrePersona, string apellidoPersona, int numeroDocumento, DateTime fechaNacimiento, int LocalidadID, string domicilio, int nro, string telefono1Persona, string instagram, string twitter, string linkedin, int generoID, IFormFile curriculPersona, IFormFile personaFoto)
        {
            byte[] cv = null;
            string tipoCV = null;
            byte[] img = null;
            string tipoImg = null;
            string domicilioCompleto = domicilio + " " + nro;
            if (personaFoto != null)
            {
                if (personaFoto.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        personaFoto.CopyTo(ms);
                        img = ms.ToArray();
                        tipoImg = personaFoto.ContentType;
                    }
                }
            }
            if (curriculPersona != null)
            {
                if (curriculPersona.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        curriculPersona.CopyTo(ms);
                        cv = ms.ToArray();
                        tipoCV = curriculPersona.ContentType;
                    }
                }
            }
            bool resultado = true;

            var generoEnum = Genero.Masculino;

            if (generoID is 1)
            {
                generoEnum = Genero.Femenino;
            }
            if (generoID is 2)
            {
                generoEnum = Genero.Otro;
            }

            var telefono1Clean = ClearNumber(telefono1Persona);

            var persona = new Persona
            {
                NombrePersona = nombrePersona,
                ApellidoPersona = apellidoPersona,
                NumeroDocumento = numeroDocumento,
                FechaNacimiento = fechaNacimiento,
                LocalidadID = LocalidadID,
                DomicilioPersona = domicilioCompleto,
                Telefono1 = telefono1Clean,
                Instagram = instagram,
                Twitter = twitter,
                Linkedin = linkedin,
                Genero = generoEnum,
                Curriculum = cv,
                TipoCV = tipoCV,
                TipoImagen = tipoImg,
                Imagen = img
            };
            resultado = false;
            _context.Add(persona);
            _context.SaveChanges();

            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            var nuevaPersonaUsuario = new PersonaUsuario
            {
                UsuarioID = usuarioActual,
                PersonaID = persona.PersonaID
            };
            _context.Add(nuevaPersonaUsuario);
            _context.SaveChanges();

            return Json(resultado);
        }

    }

}
