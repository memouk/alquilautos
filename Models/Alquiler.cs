using System.ComponentModel.DataAnnotations;

namespace alquilautos.Models;

public class Alquiler
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    public int Price { get; set; }
}