using System.ComponentModel.DataAnnotations;

namespace MasterCrud.Dtos
{
    public class CityCreateDto
    {
        [Required] [StringLength(40)] public string Description { get; set; }
    }
}