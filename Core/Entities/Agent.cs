using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Agent
    {
        public int Id { get; set; }
        [Required] [StringLength(40)] public string Name { get; set; }
        [Required] [StringLength(40)] public string LastName { get; set; }
        public int NumId { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
