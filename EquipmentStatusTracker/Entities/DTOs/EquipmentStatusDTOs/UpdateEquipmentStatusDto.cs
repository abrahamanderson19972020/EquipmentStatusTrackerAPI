using Entities.Concrete;
using Entities.DTOs.GpsPositionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EquipmentStatusDTOs
{
    public class UpdateEquipmentStatusDto
    {
        public int Id { get; set; }
        public int EquipmentShippingDetailId { get; set; }
        public int CustomerId { get; set; }
    }
}
