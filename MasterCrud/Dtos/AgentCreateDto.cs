using System.ComponentModel.DataAnnotations;

namespace MasterCrud.Dtos
{
    public class AgentCreateDto
    {
        [Required] [StringLength(40)] public string Name { get; set; }
        [Required] [StringLength(40)] public string LastName { get; set; }
        [StringLength(40)] public int NumId { get; set; }

        public int CityId { get; set; }
    }
}
