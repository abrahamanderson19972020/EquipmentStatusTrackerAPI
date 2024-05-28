using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EquipmentStatusDTOs
{
    public class CreateEquipmentStatusDto
    {
        [Required]
        public int EquipmentShippingDetailId { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
