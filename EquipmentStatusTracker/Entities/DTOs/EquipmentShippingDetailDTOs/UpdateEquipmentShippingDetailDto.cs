using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EquipmentShippingDetailDTOs
{
    public class UpdateEquipmentShippingDetailDto
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
        public int SendingAddressId { get; set; }
        public int DestinationAddressId { get; set; }
        public string? AdditionalNotes { get; set; }
    }
}
