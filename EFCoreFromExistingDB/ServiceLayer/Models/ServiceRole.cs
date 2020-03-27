using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.Models
{
    public class ServiceRole
    {
        public int RoleId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Department { get; set; }
    }
}
