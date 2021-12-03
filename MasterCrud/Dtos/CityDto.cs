using System.ComponentModel.DataAnnotations;

namespace MasterCrud.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        [Required] [StringLength(40)] public string Description { get; set; }
    }
}