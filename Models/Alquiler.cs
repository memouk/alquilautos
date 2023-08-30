using System.ComponentModel.DataAnnotations;

namespace alquilautos.Models;

public class Alquiler
{
    public int Id { get; set; }
    public string? Descripcion { get; set; }
    [DataType(DataType.Date)]
    public DateTime FechaInicio { get; set; }

    [DataType(DataType.Date)]
    public DateTime FechaFin { get; set; }
    public int Idvehiculo { get; set; }
    public int Valor { get; set; }
}