namespace WorkNetwork.Controllers
{
    [Authorize(Roles = "SuperUsuario")]
    public class PaisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaisesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Pais.ToList());
        }

         //public JsonResult ComboPais(int id)
       // {
         ////  return Json(new SelectList(provincias, "ProvinciaID", "NombreProvincia"));
      //  }
        public JsonResult TablaPaises()
        {
            var paises = _context.Pais.ToList();
            return Json(paises);
        }
        public JsonResult CrearPais(string NombrePais,int PaisID)
        {
            int resultado = 0;
            //Si es 0 es correcto
            //Si es 1 descripcion vacia
            //Si es 2 campo existente
            if (!string.IsNullOrEmpty(NombrePais))
            {
                NombrePais = NombrePais.ToUpper(); 
                
                if(PaisID is 0)
                {
                    if(_context.Pais.Any(e=> e.NombrePais == NombrePais))
                        resultado = 2;
         
                    else
                    {
                        //Creo el pais
                        var pais = new Pais
                        {
                            NombrePais = NombrePais,
                        };
                        _context.Add(pais);
                        _context.SaveChanges();
                    }

                }
                else
                {
                    //Editar el pais
                    if(_context.Pais.Any(e => e.NombrePais == NombrePais && e.PaisID != PaisID))     
                        resultado=2;
                    
                    else
                    {
                        var pais = _context.Pais.Single(e=>e.PaisID == PaisID);
                        pais.NombrePais=NombrePais;
                        _context.SaveChanges();
                    }
                }
            }
            return Json(resultado);
        }

        // RETORNA LOS DATOS DEL CAMPO PAIS DE LA BASE DE DATOS PARA MOSTRARLOS DENTRO DEL MODAL
        public JsonResult BuscarPais(int PaisID)
        {
            var pais = _context.Pais.FirstOrDefault(p => p.PaisID == PaisID);
            return Json(pais);
        }

        public JsonResult EliminarPais(int PaisID, int Elimina)
        {
            //ArgumentNullException.ThrowIfNull(nameof(PaisID));
            int resultado = 0;

            var pais = _context.Pais.Find(PaisID);

            if (pais != null)
            {
                if (Elimina is 0)
                {
                    pais.Eliminado = false;
                    _context.SaveChanges(true);
                }
                else
                {
                    var cantidadProvincias = (from o in _context.Provincia where o.PaisID == PaisID && o.Eliminado == false select o).Count();
                    if (cantidadProvincias == 0)
                    {
                        pais.Eliminado = true;
                        _context.SaveChanges();

                    }
                    else
                    {
                        resultado = 1;
                    }
                }
            }
            return Json(resultado);
        }
    }
}
