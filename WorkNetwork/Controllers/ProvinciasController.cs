namespace WorkNetwork.Controllers
{
    [Authorize(Roles = "SuperUsuario,Empresa, Usuario")]
    public class ProvinciasController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProvinciasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "SuperUsuario")]
        public async Task<IActionResult> Index()
        {
            var paiss = _context.Pais.ToList();
            paiss.Add(new Pais { PaisID = 0, NombrePais = "[SELECCIONE UN PAIS]" });
            ViewBag.PaisID = new SelectList(paiss.OrderBy(e => e.NombrePais), "PaisID", "NombrePais");
            return View(await _context.Provincia.ToListAsync());
        }


        [Authorize(Roles = "SuperUsuario ,Usuario, Empresa")]
        public JsonResult ComboProvincia(int id)
        {
            var provincias = (from p in _context.Provincia where p.PaisID == id select p).ToList();
            return Json(new SelectList(provincias, "ProvinciaID", "NombreProvincia"));
        }

        public JsonResult TablaProvincias()
        {
            var provincias = _context.Provincia.Include(p => p.Pais).ToList();

            List<ProvinciaMostrar> listadoProvincias = new List<ProvinciaMostrar>();
            foreach (var provincia in provincias)
            {
                var provinciasVer = new ProvinciaMostrar
                {
                    ProvinciaID= provincia.ProvinciaID,
                    NombreProvincia = provincia.NombreProvincia,
                    PaisID= provincia.PaisID,
                    NombrePais = provincia.Pais.NombrePais,
                    Eliminado = provincia.Eliminado,
                };
                listadoProvincias.Add(provinciasVer);
            }

            return Json(listadoProvincias);
        }

        public JsonResult CrearProvincia(int IdProvincia, string NombreProvincia, int PaisID)
        {
            int resultado = 0;
            //Si es 0 es correcto
            //Si es 1 descripcion vacia
            //Si es 2 campo existente

            if (!string.IsNullOrEmpty(NombreProvincia)){
                NombreProvincia = NombreProvincia.ToUpper();
                if(IdProvincia is 0){
                    if(_context.Provincia.Any(e=>e.NombreProvincia == NombreProvincia && e.PaisID == PaisID )){
                        resultado = 2;
                    }else{
                        //Creo la provincia
                        var provincia = new Provincia{
                            NombreProvincia = NombreProvincia,
                            PaisID = PaisID,
                        };
                        _context.Add(provincia);
                        _context.SaveChanges();
                    }
                } else{
                    if (_context.Provincia.Any(e=>e.NombreProvincia == NombreProvincia && e.ProvinciaID != IdProvincia))
                    {
                       resultado = 2; 
                    }else{
                        var provincia = _context.Provincia.Single(e => e.ProvinciaID == IdProvincia);
                            provincia.NombreProvincia = NombreProvincia;
                            provincia.PaisID = PaisID;
                            _context.SaveChanges();
                    }
                }
            }
            return Json(resultado);
        }



        public JsonResult BuscarProvincia(int ProvinciaID)
        {
            var provincia = _context.Provincia.FirstOrDefault(m => m.ProvinciaID == ProvinciaID);

            return Json(provincia);
        }

        public JsonResult EliminarProvincia(int ProvinciaID, int Elimina)
        {
            int resultado = 0;

            var provincia = _context.Provincia.Find(ProvinciaID);
            if (provincia is not null)
            {
                if (Elimina is 0)
                {
                    provincia.Eliminado = false;
                    _context.SaveChanges();
                }
                else
                {
                    //NO PUEDE ELIMINAR LA PROVINCIA A SI TIENE LOCALIDADES
                    var cantidadlocalidades = (from o in _context.Localidad where o.ProvinciaID == ProvinciaID && o.Eliminado == false select o).Count();
                    if (cantidadlocalidades is 0)
                    {
                        provincia.Eliminado = true;
                        _context.SaveChanges();
                    }
                    else
                    {
                        resultado = 1;
                    }
                }
            }

            return Json(resultado);

            //private bool ProvinciaExists(int id)//
            //  {
            // return _context.Rubros.Any(e => e.RubroID == id);
            // }//

        }
    }
}
