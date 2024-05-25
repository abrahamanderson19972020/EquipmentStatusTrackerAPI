using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EquipmentStatusDTOs
{
    public class ResultEquipmentStatusDto
    {
        public int Id { get; set; }
        public int EquipmentShippingDetailId { get; set; }
        public ICollection<GpsPosition> GpsPositions { get; set; } = new List<GpsPosition>();
        public int CustomerId { get; set; }
    }
}
