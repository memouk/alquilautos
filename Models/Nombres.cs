using System.ComponentModel.DataAnnotations;

namespace alquilautos.Models;

public class Nombres
{
    public int NombresId { get; set; }
    public string primerNombre { get; set; }
    public string segundoNombre { get; set; }
    public string primerApellido { get; set; }
    public string segundoApellido { get; set; }

}