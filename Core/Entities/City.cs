using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class City
    {
        public int Id { get; set; }
        [Required] [StringLength(40)] public string Description { get; set; }
    }
}