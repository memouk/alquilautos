namespace alquilautos.Models;

public class Usuarios
{
    public int Id { get; set; }
    public int tipoDoc { get; set; }

    public int documento { get; set; }
    public int idNombres  { get; set; }
    public int idTelefono { get; set; }
    public int idDireccion { get; set; }
    public DateTime fechaNacimiento { get; set; }
    public DateTime fechaCreacion{ get; set; }

   
    
    
}