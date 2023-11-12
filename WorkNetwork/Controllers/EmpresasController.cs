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

        public IActionResult PerfilEmpresa(int? id) {

            var empresaMostrar = new EmpresaMostrar();

            if (id == null)
            {
                var usuarioAcutal = _userManager.GetUserId(HttpContext.User);

                var empresaUsuario = _context.EmpresaUsuarios.Where(u => u.UsuarioID == usuarioAcutal).FirstOrDefault();

                var empresa = _context.Empresa.Where(e => e.EmpresaID == empresaUsuario.EmpresaID).FirstOrDefault();
                var correo = _context.Users.Where(c => c.Id == empresaUsuario.UsuarioID).Select(c => c.Email).Single();
                var localidadNombre = _context.Localidad.Where(l => l.LocalidadID == empresa.LocalidadID).Select(l => l.NombreLocalidad).Single();
                var rubroNombre = _context.Rubro.Where(r => r.RubroID == empresa.RubroID).Select(r => r.NombreRubro).Single();
                empresaMostrar.EmpresaID = empresa.EmpresaID;
                empresaMostrar.RazonSocial = empresa.RazonSocial;
                empresaMostrar.CUIT = empresa.CUIT;
                empresaMostrar.Localidad = localidadNombre;
                empresaMostrar.Telefono1 = empresa.Telefono1;
                empresaMostrar.Descripcion = empresa.Descripcion;
                empresaMostrar.Instagram = empresa.Instagram;
                empresaMostrar.Twitter = empresa.Twitter;
                empresaMostrar.Linkedin = empresa.Linkedin;
                empresaMostrar.Domicilio = empresa.Domicilio;
                empresaMostrar.Rubro = rubroNombre;
                empresaMostrar.Correo = correo;

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

                if (empresa.Imagen != null)
                {
                    empresaMostrar.ImagenEmpresa = empresa.Imagen;
                    empresaMostrar.TipoImagen = empresa.TipoImagen;
                    empresaMostrar.Imagen = Convert.ToBase64String(empresa.Imagen);
                }

                empresaMostrar.Eliminado= empresa.Eliminado;
            }
            else
            {
                var empresa = _context.Empresa.Where(u => u.EmpresaID == id).FirstOrDefault();
                var localidad = _context.Localidad.Where(u => u.LocalidadID == empresa.LocalidadID).Select(l => l.NombreLocalidad);

                empresaMostrar.EmpresaID = empresa.EmpresaID;
                empresaMostrar.RazonSocial = empresa.RazonSocial;
                empresaMostrar.CUIT = empresa.CUIT;
                empresaMostrar.Domicilio = empresa.Domicilio;
                empresaMostrar.Rubro = empresa.Rubro.NombreRubro;

                if (empresa.Imagen != null)
                {
                    empresaMostrar.ImagenEmpresa = empresa.Imagen;
                    empresaMostrar.TipoImagen = empresa.TipoImagen;
                    empresaMostrar.Imagen = Convert.ToBase64String(empresa.Imagen);
                }
                empresaMostrar.Eliminado= empresa.Eliminado;
            }

            ViewData["empresa"] = empresaMostrar;
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
        public JsonResult GuardarEmpresa(int IDempresa, string razonSocial, string cuitEmpresa, string telefono1Empresa, string descripcion, string instagram, string twitter, string linkedin, int LocalidadID, string domicilio, int nro, int RubroID, IFormFile empresaFoto)
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
                RazonSocial = razonSocial,
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

        public JsonResult EditarEmpresa(int IdEmpresa, string razonSocial, string cuitEmpresa, int LocalidadID, string domicilio, string telefono1Empresa, string correoEmpresa)
        {
            //no actualiza los datos
            var telefono1Clean = ClearNumber(telefono1Empresa);
            //    //string domicilioCompleto = domicilio + " " + nro;
            var empresa = _context.Empresa.FirstOrDefault(p => p.EmpresaID == IdEmpresa);
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            var empresaUsuario = _context.EmpresaUsuarios.Where(u => u.UsuarioID == usuarioActual).FirstOrDefault();
            var user = _context.Users.Where(u => u.Id == empresaUsuario.UsuarioID).Single();

            empresa.RazonSocial = razonSocial;
            empresa.CUIT = cuitEmpresa;
            empresa.LocalidadID = LocalidadID;
            empresa.Domicilio = domicilio;
            user.Email = correoEmpresa;
            empresa.Telefono1 = telefono1Clean;

            _context.Update(empresa);
            _context.Update(user);
            _context.SaveChanges();

            return Json(empresa);
        }


        public JsonResult BuscarEmpresa(int EmpresaID)
        {
            var empresa = _context.Empresa.Include(l => l.Localidad).FirstOrDefault(m => m.EmpresaID == EmpresaID);
            var provincia = _context.Provincia.Where(p => p.ProvinciaID == empresa.Localidad.ProvinciaID).FirstOrDefault();
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            var empresaUsuario = _context.EmpresaUsuarios.Where(u => u.UsuarioID== usuarioActual).FirstOrDefault();
            var correo = _context.Users.Where(u => u.Id == empresaUsuario.UsuarioID).Select(u => u.Email).Single();

            var empresaVer = new EmpresaMostrar
            {
                EmpresaID = empresa.EmpresaID,
                RazonSocial= empresa.RazonSocial,
                CUIT = empresa.CUIT,
                Telefono1= empresa.Telefono1,
                PaisID = provincia.PaisID,
                ProvinciaID = provincia.ProvinciaID,
                LocalidadID = empresa.LocalidadID,
                Domicilio =empresa.Domicilio,
                Correo= correo,

            };

            return Json(empresaVer);
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
