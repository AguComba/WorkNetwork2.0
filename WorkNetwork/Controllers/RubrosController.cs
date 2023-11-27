namespace WorkNetwork.Controllers
{
    [Authorize(Roles = "SuperUsuario")]
    public class RubrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RubrosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Rubro.ToList());
        }
        public JsonResult TablaRubros()
        {
            var rubros = _context.Rubro.ToList();
            return Json(rubros);
        }

        public JsonResult GuardarRubro(int idRubro, string NombreRubro)
        {
            int resultado = 0;
            //Si es 0 es correcto
            //Si es 1 descripcion vacia
            //Si es 2 campo existente
            if (!string.IsNullOrEmpty(NombreRubro))
            {
                NombreRubro = NombreRubro.ToUpper();
                if (idRubro is 0)
                {
                    if (_context.Rubro.Any(e => e.NombreRubro == NombreRubro))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //Aca va el crear
                        var rubroCrear = new Rubro
                        {
                            NombreRubro = NombreRubro
                        };
                        _context.Add(rubroCrear);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (_context.Rubro.Any(e => e.NombreRubro == NombreRubro && e.RubroID != idRubro))
                    {
                        resultado = 2;
                    }
                    else
                    {
                        //Aca va el editar
                        var rubro = _context.Rubro.Single(p => p.RubroID == idRubro);
                        rubro.NombreRubro = NombreRubro;
                        _context.SaveChanges();
                    }
                }

            }

            return Json(resultado);
        }

         public JsonResult BuscarRubro(int RubroID)
        {
            var rubro = _context.Rubro.FirstOrDefault(m => m.RubroID == RubroID);

            return Json(rubro);
        }

        public JsonResult EliminarRubro(int RubroID, int Elimina)
        {
            int resultado = 0;

            var rubro = _context.Rubro.Find(RubroID);
            if (rubro is not null)
            {
                bool rubroUsado = _context.Empresa.Any(e=>e.RubroID == RubroID)||
                                  _context.Vacante.Any(v=>v.RubroID == RubroID);

                if (rubroUsado)
                {   
                    //Rubro en uso
                    resultado = 3;
                }
                else
                {   
                    //Rubro no se usa. ELIMINAR
                    if (Elimina is 0)
                    {
                        rubro.Eliminado = false;
                        _context.SaveChanges();
                    }
                    else
                    {
                        //NO PUEDE ELIMINAR RUBRO SI TIENE USUARIOS ACTIVOS
                         rubro.Eliminado = true;
                        _context.SaveChanges();

                    }
                }                             
            }

            return Json(resultado);
        }
      
        private bool RubroExists(int id)
        {
            return _context.Rubro.Any(e => e.RubroID == id);
        }

    }
}
