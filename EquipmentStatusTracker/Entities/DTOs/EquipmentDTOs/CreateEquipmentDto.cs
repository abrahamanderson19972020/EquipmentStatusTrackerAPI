using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EquipmentDTOs
{
    public class CreateEquipmentDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
