using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EquipmentShippingDetailDTOs
{
    public class CreateEquipmentShippingDetailDto
    {
        [Required]
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int SendingAddressId { get; set; }
        [Required]
        public int DestinationAddressId { get; set; }
        public string? AdditionalNotes { get; set; }
    }
}
