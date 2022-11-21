namespace WorkNetwork.Models
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public int NumeroDocumento { get; set; }
        public string? Instagram { get; set; }
        public string? Linkedin { get; set; }
        public string? Twitter { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? DomicilioPersona { get; set; }
        public int LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }
        public Genero Genero { get; set; }
        public string Telefono1 { get; set; }
        public string? EstadoCivil { get; set; }
        public byte[]? Imagen { get; set; }
        public byte[]? Curriculum { get; set; }
        public string? TipoCV { get; set; }
        public string? TipoImagen { get; set; }
        public bool Eliminado { get; set; }

    }
    public enum Genero
    {
        Masculino, Femenino, Otro
    }

    public class PersonaMostrar
    {
        public int PersonaID { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPersona { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public int NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? DomicilioPersona { get; set; }
        public int LocalidadID { get; set; }
        public string LocalidadNombre { get; set; }
        public string Correo { get; set; }
        public Genero Genero { get; set; }
        public string Telefono1 { get; set; }
        public string? EstadoCivil { get; set; }
        public byte[] ImagenPersona { get; set; }
        public string? TipoImagen { get; set; }
        public string Imagen { get; set; }
        public byte[] Curriculum { get; set; }
        public string TipoCV { get; set; }
        public string CurriculumString { get; set; }
        public bool Eliminado { get; set; }
    }
}



