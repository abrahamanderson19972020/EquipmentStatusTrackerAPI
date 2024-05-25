using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EquipmentShippingDetailDTOs
{
    public class ResultEquipmentShippingDetailDto
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int Quantity { get; set; }
        public int SendingAddressId { get; set; }
        public int DestinationAddressId { get; set; }
        public string? AdditionalNotes { get; set; }
    }
}
