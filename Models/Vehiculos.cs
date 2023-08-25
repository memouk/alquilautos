using System.ComponentModel.DataAnnotations;

namespace alquilautos.Models;

public class Vehiculos
{
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    [Display(Name = "Placa")]
    
    public string? Placa { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime creacion { get; set; }
    public int idMarca { get; set; }
    public int idConductor { get; set; }
    public int idPropietario { get; set; }
    public int idTenedor { get; set; }

    [DataType(DataType.Date)]
    public DateTime vencimientoSoat { get; set; }
    public int tipoVehiculo { get; set; }
}