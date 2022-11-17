namespace WorkNetwork.Models

{
    public class Empresa
    {
        [Key]
        public int EmpresaID { get; set; }
        public string? RazonSocial { get; set; }
        public string CUIT { get; set; }
        public int LocalidadID { get; set; }
        public virtual Localidad? Localidad { get; set; }
        public string Telefono1 { get; set; }
        public string Descripcion { get; set; }
        public string? Instagram {get; set;}
        public string? Twitter {get; set;}
        public string? Linkedin {get; set;}
        public string Domicilio {get; set;}
        public byte[]? Imagen { get; set; }
        public string? TipoImagen { get; set; }
        public string? ImagenRecortada {get; set;}
        public int RubroID { get; set; }
        public bool Eliminado { get; set; }
        public virtual Rubro? Rubro { get; set; }
        public virtual ICollection<Vacante>? Vacantes { get; set; }
    }
}