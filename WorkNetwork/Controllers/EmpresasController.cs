namespace WorkNetwork.Controllers
{
    [Authorize(Roles = "Empresa, SuperUsuario")]
    public class EmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public EmpresasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
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
            if (rolNombre is "Empresa")
            {

                var personaUsuario = (from p in _context.EmpresaUsuarios where p.UsuarioID == usuarioActual select p).Count();
                if (personaUsuario == 0)
                {
                    return RedirectToAction("NewEmpresa", "Empresas");
                }
            }
            return View();
        }

        public IActionResult PerfilEmpresa() { 
            return View();
        }

        public IActionResult NewEmpresa()
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

            var rubros = _context.Rubro.ToList();
            rubros.Add(new Rubro { RubroID = 0, NombreRubro = "[SELECCIONE UN RUBRO]" });
            ViewBag.RubroID = new SelectList(rubros.OrderBy(x => x.NombreRubro), "RubroID", "NombreRubro");

            return View();
        }

        public JsonResult TablaEmpresas()
        {
            var empresas = _context.Empresa.ToList();
            return Json(empresas);
        }

        //Metodo para limpiar el numero telefonico
        static string ClearNumber(string numero) => new string((numero ?? "").Where(c => c == '+' || char.IsNumber(c)).ToArray());
        public JsonResult GuardarEmpresa(int IDempresa, string empresaNombre, string cuitEmpresa, string telefono1Empresa, string descripcion, string instagram, string twitter, string linkedin, int LocalidadID, string domicilio, int nro, int RubroID, IFormFile empresaFoto)
        {
            byte[] img = null;
            string tipoImg = null;
            if (empresaFoto != null)
            {
                if (empresaFoto.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        empresaFoto.CopyTo(ms);
                        img = ms.ToArray();
                        tipoImg = empresaFoto.ContentType;
                    }
                }
            }

            var resultado = true;
            var telefono1Clean = ClearNumber(telefono1Empresa);
            var domicilioCompleto = domicilio + " " + nro;

            var nuevaEmpresa = new Empresa
            {
                RazonSocial = empresaNombre,
                CUIT = cuitEmpresa,
                Telefono1 = telefono1Clean,
                Descripcion = descripcion,
                Instagram = instagram,
                Twitter = twitter,
                Linkedin = linkedin,
                LocalidadID = LocalidadID,
                Domicilio = domicilioCompleto,
                RubroID = RubroID,
                Imagen = img,
                TipoImagen = tipoImg,
            };
            _context.Add(nuevaEmpresa);
            _context.SaveChanges();

            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            var nuevoEmpresaUsuario = new EmpresaUsuario
            {
                UsuarioID = usuarioActual,
                EmpresaID = nuevaEmpresa.EmpresaID
            };
            _context.Add(nuevoEmpresaUsuario);
            _context.SaveChanges();
            return Json(resultado);

        }


        public JsonResult BuscarEmpresa(int EmpresaID)
        {
            var empresa = _context.Empresa.FirstOrDefault(m => m.EmpresaID == EmpresaID);

            return Json(empresa);
        }

        public JsonResult EliminarEmpresa(int EmpresaID, int Elimina)
        {
            int resultado = 0;

            var empresa = _context.Empresa.Find(EmpresaID);
            if (empresa != null)
            {
                if (Elimina == 0)
                {
                    empresa.Eliminado = false;
                    _context.SaveChanges();
                }
                else
                {
                    empresa.Eliminado = true;
                    //NO PUEDE ELIMINAR EMPRESA SI TIENE RUBROS ACTIVOS
                    //var cantidadRubros = (from o in _context.Rubro where o.EmpresaID == EmpresaID && o.Eliminado == false select o).Count();
                    //if (cantidadRubros == 0)
                    //{
                    //    empresa.Eliminado = true;
                    //    _context.SaveChanges();
                    //}
                    //else
                    //{
                    //    resultado = 1;
                    //}
                }
                _context.SaveChanges();
            }

            return Json(resultado);


        }
        private bool RubroExists(int id)
        {
            return _context.Rubro.Any(e => e.RubroID == id);
        }

    }

}
