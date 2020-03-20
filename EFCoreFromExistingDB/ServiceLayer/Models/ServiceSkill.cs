using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Models
{
    public class ServiceSkill
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
