namespace WorkNetwork.Controllers
{
    public class PersonaVacanteController: Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public PersonaVacanteController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public JsonResult BuscarVacante (int vacanteID){
            var vacante = _context.Vacante.FirstOrDefault(v => v.VacanteID == vacanteID);
            return Json(vacante);
        }
        public JsonResult postularVacante (int vacanteID, string descripcionVacante){
            var result = true;
            var usuarioActual = _userManager.GetUserId(HttpContext.User);

            //EN BASE A ESE ID BUSCAMOS EN LA TABLA DE RELACION USUARRIO-EMPRESA QUE REGISTRO TIENE
            var personaUsuario = _context.PersonaUsuarios
                .Where(u => u.UsuarioID == usuarioActual)
                .FirstOrDefault();

            //EN BASE A ESA VARIABLE RECURRIMOS AL ID DE LA EMPRESA ACTUAL PARA RELACIONARLA CON LA VACANTE 
            var personaID = _context.PersonaUsuarios
                .Where(u => u.PersonaID == personaUsuario.PersonaID)
                .Select(r=>r.PersonaID).FirstOrDefault();

            var nuevaPostulacion = new PersonaVacante{
                PersonaID = personaID,
                VacanteID = vacanteID,
                DescripcionDePersona = descripcionVacante,
                NotificacionVista = true, 
                FechaSolicitud = DateTime.Now, 
            };
            _context.Add(nuevaPostulacion);
            _context.SaveChanges();
            return Json(result);
        } 
    }
}