namespace WorkNetwork.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? DomicilioPersona { get; set; }
        public int LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }
        public SituacionLaboral SituacionLaboral { get; set; }
        public Genero Genero { get; set; }
        public string Telefono1 { get; set; }
        public string   ? Telefono2 { get; set; }
        public string? EstadoCivil { get; set; }
        public string? TituloAcademico { get; set; }
        public int? CantidadHijos { get; set; }
        public byte[]? Imagen { get; set; }
        public string? TipoImagen{ get; set; }
        public string? ImagenRecortada {get; set;}
        public bool Eliminado { get; set; }

        //public virtual ICollection<PersonaVacante>? PersonaVacante { get; set; }

        //RELACION UNA PERSONA A MUCHOS RUBROS
    }
    public enum SituacionLaboral
    {
        Empleado, Desempleado,
    }

    public enum Genero
    {
        Masculino, Femenino, Otro
    }

    public enum TipoDocumento
    {
        dni, LE
    }

    public class PersonaMostrar {
        public int PersonaID { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? DomicilioPersona { get; set; }
        public int LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }
        public SituacionLaboral SituacionLaboral { get; set; }
        public Genero Genero { get; set; }
        public string Telefono1 { get; set; }
        public string   ? Telefono2 { get; set; }
        public string? EstadoCivil { get; set; }
        public string? TituloAcademico { get; set; }
        public int? CantidadHijos { get; set; }
        public byte[] ImagenPersona {get; set;}
        public string Imagen { get; set; }
        public string? TipoImagen{ get; set; }
        public string? ImagenRecortada {get; set;}
        public bool Eliminado { get; set; }
    }
}
