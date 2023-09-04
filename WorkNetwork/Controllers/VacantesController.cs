namespace WorkNetwork.Controllers
{
    //(Roles = "Empresa, SuperUsuario")
    [Authorize]
    public class VacantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public VacantesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
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
        public IActionResult VerPDF(int id)
        {
            var persona = _context.Persona.Where(p => p.PersonaID == id).FirstOrDefault();
            if (persona.Curriculum != null)
            {
                var personaMostrar = new PersonaMostrar
                {
                    Curriculum = persona.Curriculum,
                    TipoCV = persona.TipoCV,
                    CurriculumString = Convert.ToBase64String(persona.Curriculum)
                };
                ViewData["persona"] = personaMostrar;
            }

            return View();
        }
        public IActionResult VacanteDetalle(int id)
        {
            var vacante = _context.Vacante.Where(v => v.VacanteID == id).FirstOrDefault();
            var rubroNombre = _context.Rubro.Where(r => r.RubroID == vacante.RubroID).Select(n => n.NombreRubro).Single();
            var localidadNombre = _context.Localidad.Where(l => l.LocalidadID == vacante.LocalidadID).Select(l => l.NombreLocalidad).Single();
            var vacanteEmpresa = _context.VacanteEmpresas.Where(v => v.VacanteID == id).FirstOrDefault();
            var imgEmpresa = _context.Empresa.Where(e => e.EmpresaID == vacanteEmpresa.EmpresaID).Select(i => i.Imagen).Single();
            var tipoImg = _context.Empresa.Where(e => e.EmpresaID == vacanteEmpresa.EmpresaID).Select(i => i.TipoImagen).Single();
            var empresaNombre = _context.Empresa.Where(e => e.EmpresaID == vacanteEmpresa.EmpresaID).Select(r => r.RazonSocial).Single();
            if (imgEmpresa != null)
            {
                var vacanteMostrar = new VacanteMostrar
                {
                    VacanteID = vacante.VacanteID,
                    Nombre = vacante.Nombre,
                    Descripcion = vacante.Descripcion,
                    ExperienciaRequerida = vacante.ExperienciaRequerida,
                    LocalidadNombre = localidadNombre,
                    RubroNombre = rubroNombre,
                    FechaDeFinalizacion = vacante.FechaDeFinalizacion,
                    Idiomas = vacante.Idiomas,
                    Eliminado = vacante.Eliminado,
                    ImagenVacante = Convert.ToBase64String(imgEmpresa),
                    TipoImagen = tipoImg,
                    EmpresaNombre = empresaNombre,
                    FechaCreacion = vacante.FechaCreacion,
                    DisponibilidadHoraria = vacante.DisponibilidadHoraria,
                    tipoModalidad = vacante.tipoModalidad
                };
                ViewData["vacante"] = vacanteMostrar;
            }
            else
            {
                var vacanteMostrar = new VacanteMostrar
                {
                    VacanteID = vacante.VacanteID,
                    Nombre = vacante.Nombre,
                    Descripcion = vacante.Descripcion,
                    ExperienciaRequerida = vacante.ExperienciaRequerida,
                    LocalidadNombre = localidadNombre,
                    RubroNombre = rubroNombre,
                    FechaDeFinalizacion = vacante.FechaDeFinalizacion,
                    Idiomas = vacante.Idiomas,
                    Eliminado = vacante.Eliminado,
                    EmpresaNombre = empresaNombre,
                    FechaCreacion = vacante.FechaCreacion,
                    DisponibilidadHoraria = vacante.DisponibilidadHoraria,
                    tipoModalidad = vacante.tipoModalidad
                };
                ViewData["vacante"] = vacanteMostrar;
            }

            return View();
        }

        public IActionResult GestionDeVacante(int id)
        {
            var vacante = _context.Vacante.Where(v => v.VacanteID == id).FirstOrDefault();
            var rubroNombre = _context.Rubro.Where(r => r.RubroID == vacante.RubroID).Select(n => n.NombreRubro).Single();
            var localidadNombre = _context.Localidad.Where(l => l.LocalidadID == vacante.LocalidadID).Select(l => l.NombreLocalidad).Single();
            var vacanteEmpresa = _context.VacanteEmpresas.Where(v => v.VacanteID == id).FirstOrDefault();
            var imgEmpresa = _context.Empresa.Where(e => e.EmpresaID == vacanteEmpresa.EmpresaID).Select(i => i.Imagen).Single();
            var tipoImg = _context.Empresa.Where(e => e.EmpresaID == vacanteEmpresa.EmpresaID).Select(i => i.TipoImagen).Single();
            var empresaNombre = _context.Empresa.Where(e => e.EmpresaID == vacanteEmpresa.EmpresaID).Select(r => r.RazonSocial).Single();
            if (imgEmpresa != null)
            {
                var vacanteMostrar = new VacanteMostrar
                {
                    VacanteID = vacante.VacanteID,
                    Nombre = vacante.Nombre,
                    Descripcion = vacante.Descripcion,
                    ExperienciaRequerida = vacante.ExperienciaRequerida,
                    LocalidadNombre = localidadNombre,
                    RubroNombre = rubroNombre,
                    FechaDeFinalizacion = vacante.FechaDeFinalizacion,
                    Idiomas = vacante.Idiomas,
                    Eliminado = vacante.Eliminado,
                    ImagenVacante = Convert.ToBase64String(imgEmpresa),
                    TipoImagen = tipoImg,
                    EmpresaNombre = empresaNombre,
                    FechaCreacion = vacante.FechaCreacion,
                    DisponibilidadHoraria = vacante.DisponibilidadHoraria,
                    tipoModalidad = vacante.tipoModalidad
                };
                ViewData["vacante"] = vacanteMostrar;
            }
            else
            {
                var vacanteMostrar = new VacanteMostrar
                {
                    VacanteID = vacante.VacanteID,
                    Nombre = vacante.Nombre,
                    Descripcion = vacante.Descripcion,
                    ExperienciaRequerida = vacante.ExperienciaRequerida,
                    LocalidadNombre = localidadNombre,
                    RubroNombre = rubroNombre,
                    FechaDeFinalizacion = vacante.FechaDeFinalizacion,
                    Idiomas = vacante.Idiomas,
                    Eliminado = vacante.Eliminado,
                    EmpresaNombre = empresaNombre,
                    FechaCreacion = vacante.FechaCreacion,
                    DisponibilidadHoraria = vacante.DisponibilidadHoraria,
                    tipoModalidad = vacante.tipoModalidad
                };
                ViewData["vacante"] = vacanteMostrar;
            }

            var personas = new List<PersonaMostrar>();
            var personasVacante = _context.PersonaVacante.Where(v => v.VacanteID == id).ToList();
            foreach (var personaVacante in personasVacante)
            {
                var persona = _context.Persona.Where(p => p.PersonaID == personaVacante.PersonaID).Single();
                var comentarioVacante = _context.PersonaVacante.Where(v => v.PersonaID == persona.PersonaID && v.VacanteID == id).Select(c => c.DescripcionDePersona).Single();
                if (persona.Imagen != null)
                {
                    var personaMostrar = new PersonaMostrar
                    {
                        PersonaID = persona.PersonaID,
                        NombrePersona = persona.NombrePersona,
                        ApellidoPersona = persona.ApellidoPersona,
                        Instagram = persona.Instagram,
                        Linkedin = persona.Linkedin,
                        Twitter = persona.Twitter,
                        ImagenPersona = persona.Imagen,
                        TipoImagen = persona.TipoImagen,
                        Imagen = Convert.ToBase64String(persona.Imagen),
                        ComentarioVacante = comentarioVacante,
                    };
                    personas.Add(personaMostrar);
                }
                else
                {
                    var personaMostrar = new PersonaMostrar
                    {
                        PersonaID = persona.PersonaID,
                        NombrePersona = persona.NombrePersona,
                        ApellidoPersona = persona.ApellidoPersona,
                        Instagram = persona.Instagram,
                        Linkedin = persona.Linkedin,
                        Twitter = persona.Twitter,
                        ComentarioVacante = comentarioVacante,
                    };
                    personas.Add(personaMostrar);
                }
            }
            ViewBag.PersonasMostrar = personas.ToList();
            return View();
        }



        [Authorize(Roles = "Empresa")]
        public JsonResult TablaVacasntes()
        {
            //BUSCO EL USUARIO ACTUAL
            var usuarioActual = _userManager.GetUserId(HttpContext.User);
            //EN BASE A ESE ID BUSCAMOS EN LA TABLA DE RELACION USUARRIO-EMPRESA QUE REGISTRO TIENE
            var empresaUsuario = _context.EmpresaUsuarios.Where(u => u.UsuarioID == usuarioActual).FirstOrDefault();
            //EN BASE A ESA VARIABLE RECURRIMOS AL ID DE LA EMPRESA ACTUAL PARA RELACIONARLA CON LA VACANTE 
            var empresaID = _context.EmpresaUsuarios.Where(u => u.EmpresaID == empresaUsuario.EmpresaID).Select(r => r.EmpresaID).FirstOrDefault();
            var listaVacantes = new List<Vacante>();
            var vacantesEmpresa = _context.VacanteEmpresas.Where(u => u.EmpresaID == empresaID).ToList();
            var vacantes = _context.Vacante.ToList();
            foreach (var vacante in vacantes)
            {
                var existeRelacion = vacantesEmpresa.Where(v => v.VacanteID == vacante.VacanteID).Count();
                if (existeRelacion != 0)
                {
                    listaVacantes.Add(vacante);
                }
            }

            return Json(listaVacantes);
        }

        public JsonResult MostrarVantes()
        {
            var usuarioActual = _userManager.GetUserId(HttpContext.User);

            var rolUsuario = _context.UserRoles.Where(u => u.UserId == usuarioActual).FirstOrDefault();
            var rolNombre = _context.Roles.Where(u => u.Id == rolUsuario.RoleId).Select(r => r.Name).FirstOrDefault();
            var listaVacantes = new List<VacanteMostrar>();
            if (rolNombre is "Usuario")
            {
                var personaUsuario = _context.PersonaUsuarios.Where(u => u.UsuarioID == usuarioActual).FirstOrDefault();
                var vacantesPostuladas = _context.PersonaVacante.Where(u => u.PersonaID == personaUsuario.PersonaID).ToList();
                var vacantes = _context.Vacante.ToList();
                foreach (var vacante in vacantes)
                {
                    var existePostulacion = vacantesPostuladas.Where(v => v.VacanteID == vacante.VacanteID).Count();
                    if (existePostulacion == 0)
                    {
                        var empresaID = _context.VacanteEmpresas.Where(v => v.VacanteID == vacante.VacanteID).Select(e => e.EmpresaID).Single();
                        var empresaNombre = _context.Empresa.Where(e => e.EmpresaID == empresaID).Select(e => e.RazonSocial).Single();
                        var rubroNombre = _context.Rubro.Where(r => r.RubroID == vacante.RubroID).Select(n => n.NombreRubro).Single();
                        var localidadNombre = _context.Localidad.Where(l => l.LocalidadID == vacante.LocalidadID).Select(l => l.NombreLocalidad).Single();
                        var imgEmpresa = _context.Empresa.Where(e => e.EmpresaID == empresaID).Select(i => i.Imagen).Single();
                        var tipoImg = _context.Empresa.Where(e => e.EmpresaID == empresaID).Select(i => i.TipoImagen).Single();
                        if (imgEmpresa == null)
                        {
                            var vacanteMostrar = new VacanteMostrar
                            {
                                VacanteID = vacante.VacanteID,
                                Nombre = vacante.Nombre,
                                Descripcion = vacante.Descripcion,
                                ExperienciaRequerida = vacante.ExperienciaRequerida,
                                LocalidadNombre = localidadNombre,
                                RubroNombre = rubroNombre,
                                FechaDeFinalizacion = vacante.FechaDeFinalizacion,
                                FechaCreacion = vacante.FechaCreacion,
                                Idiomas = vacante.Idiomas,
                                Eliminado = vacante.Eliminado,
                                DisponibilidadHoraria = vacante.DisponibilidadHoraria,
                                tipoModalidad = vacante.tipoModalidad,
                                EmpresaNombre = empresaNombre
                            };
                            listaVacantes.Add(vacanteMostrar);
                        }
                        else
                        {
                            var vacanteMostrar = new VacanteMostrar
                            {
                                VacanteID = vacante.VacanteID,
                                Nombre = vacante.Nombre,
                                Descripcion = vacante.Descripcion,
                                ExperienciaRequerida = vacante.ExperienciaRequerida,
                                LocalidadNombre = localidadNombre,
                                RubroNombre = rubroNombre,
                                FechaDeFinalizacion = vacante.FechaDeFinalizacion,
                                FechaCreacion = vacante.FechaCreacion,
                                Idiomas = vacante.Idiomas,
                                Eliminado = vacante.Eliminado,
                                DisponibilidadHoraria = vacante.DisponibilidadHoraria,
                                tipoModalidad = vacante.tipoModalidad,
                                ImagenVacante = Convert.ToBase64String(imgEmpresa),
                                TipoImagen = tipoImg,
                                EmpresaNombre = empresaNombre
                            };
                            listaVacantes.Add(vacanteMostrar);
                        }
                    }
                }
            }
            return Json(listaVacantes);
        }

        public JsonResult GuardarVacante(int vacanteID, string tituloVacante,
            string descripcionVacante, string experienciaRequerida, int LocalidadID, int RubroID,
            DateTime fechaFinalizacion, string idiomaVacante, string ImagenString,
            string Estado, int disponibilidadHoraria, int modalidadVacante)
        {
            var resultado = true;
            var disponibilidadHorariaEnum = DisponibilidadHoraria.fulltime;

            if (disponibilidadHoraria is 1) disponibilidadHorariaEnum = DisponibilidadHoraria.partime;

            var tipoModalidadEnum = tipoModalidad.presencial;

            if (modalidadVacante is 1) tipoModalidadEnum = tipoModalidad.semipresencial;

            else
                tipoModalidadEnum = tipoModalidad.remoto;


            if (vacanteID is 0)
            {
                var nuevaVacante = new Vacante
                {
                    Nombre = tituloVacante,
                    Descripcion = descripcionVacante,
                    ExperienciaRequerida = experienciaRequerida,
                    LocalidadID = LocalidadID,
                    FechaDeFinalizacion = fechaFinalizacion,
                    FechaCreacion = DateTime.Now.Date,
                    Idiomas = idiomaVacante,
                    RubroID = RubroID,
                    Estado = Estado,
                    Eliminado = false,
                    DisponibilidadHoraria = disponibilidadHorariaEnum,
                    tipoModalidad = tipoModalidadEnum,

                };
                _context.Add(nuevaVacante);
                _context.SaveChanges();

                //BUSCO EL USUARIO ACTUAL
                var usuarioActual = _userManager.GetUserId(HttpContext.User);
                //EN BASE A ESE ID BUSCAMOS EN LA TABLA DE RELACION USUARRIO-EMPRESA QUE REGISTRO TIENE
                var empresaUsuario = _context.EmpresaUsuarios.Where(u => u.UsuarioID == usuarioActual).FirstOrDefault();
                //EN BASE A ESA VARIABLE RECURRIMOS AL ID DE LA EMPRESA ACTUAL PARA RELACIONARLA CON LA VACANTE 
                var empresaID = _context.EmpresaUsuarios.Where(u => u.EmpresaID == empresaUsuario.EmpresaID).Select(r => r.EmpresaID).FirstOrDefault();
                var nuevaEmpresaVacante = new VacanteEmpresa
                {
                    VacanteID = nuevaVacante.VacanteID,
                    EmpresaID = empresaID
                };
                _context.Add(nuevaEmpresaVacante);
                _context.SaveChanges();
            }
            else
            {
                var usuarioActual = _userManager.GetUserId(HttpContext.User);
                var empresaUsuario = _context.EmpresaUsuarios.Where(u => u.UsuarioID == usuarioActual).Select(e => e.UsuarioID);
                //si el usuario es igual que el usuario actual lo permito editar

                if (_context.Vacante.Any(e => e.Nombre == tituloVacante && e.VacanteID != vacanteID))
                {
                    resultado = false;
                }
                else
                {
                    var vacante = _context.Vacante.Single(v => v.VacanteID == vacanteID);
                    vacante.Nombre = tituloVacante;
                    vacante.Descripcion = descripcionVacante;
                    vacante.ExperienciaRequerida = experienciaRequerida;
                    vacante.LocalidadID = LocalidadID;
                    vacante.FechaDeFinalizacion = fechaFinalizacion;
                    vacante.Idiomas = idiomaVacante;
                    vacante.RubroID = RubroID;
                    vacante.Estado = Estado;
                    vacante.Eliminado = false;
                    vacante.DisponibilidadHoraria = disponibilidadHorariaEnum;
                    vacante.tipoModalidad = tipoModalidadEnum;
                    _context.SaveChanges();
                }

            }

            return Json(resultado);
        }


        public JsonResult BuscarVacante(int VacanteID)
        {
            var vacante = _context.Vacante.FirstOrDefault(m => m.VacanteID == VacanteID);
            var localidad = _context.Localidad.Where(p => p.LocalidadID == vacante.LocalidadID).FirstOrDefault();
            var provincia = _context.Provincia.Where(p => p.ProvinciaID == localidad.ProvinciaID).FirstOrDefault();

            var vacanteVer = new VacanteMostrar
            {
                VacanteID = vacante.VacanteID,
                Nombre = vacante.Nombre,
                Descripcion = vacante.Descripcion,
                ExperienciaRequerida = vacante.ExperienciaRequerida,
                RubroID = vacante.RubroID,
                FechaDeFinalizacion = vacante.FechaDeFinalizacion,
                LocalidadID = vacante.LocalidadID,
                ProvinciaID = localidad.ProvinciaID,
                PaisID = provincia.PaisID,
                Idiomas = vacante.Idiomas,
                DisponibilidadHoraria = vacante.DisponibilidadHoraria,
                tipoModalidad = vacante.tipoModalidad,
            };

            return Json(vacanteVer);
        }

        public JsonResult EliminarVacante(int VacanteID, int Elimina)
        {
            int resultado = 0;

            var vacante = _context.Vacante.Find(VacanteID);
            if (vacante is not null)
            {
                if (Elimina is 0)
                {
                    vacante.Eliminado = false;
                    _context.SaveChanges();
                }
                else
                {
                    //NO PUEDE ELIMINAR EMPRESA SI TIENE RUBROS ACTIVOS
                    // var cantidadRubros = (from o in _context.Rubros where o.EmpresaID == EmpresaID && o.Eliminado == false select o).Count();
                    //if (cantidadRubros == 0)
                    //{
                    //Vacante.Eliminado = true;
                    //_context.SaveChanges();
                    //}
                    //else
                    //{
                      resultado = 1;
                    //}
                }
            }

            return Json(resultado);

        }
        private bool VacanteExists(int id)
        {
            return _context.Vacante.Any(e => e.VacanteID == id);
        }
    }
}

