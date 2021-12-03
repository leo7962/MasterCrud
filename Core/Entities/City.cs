using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Required] [StringLength(40)] public string Description { get; set; }

        public ICollection<Agent> Agents { get; set; }
    }
}