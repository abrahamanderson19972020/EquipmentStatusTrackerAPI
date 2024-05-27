using Entities.Concrete;
using Entities.DTOs.EquipmentShippingDetailDTOs;
using Entities.DTOs.GpsPositionDTOs;
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
        public ResultEquipmentShippingDetailDto EquipmentShippingDetail { get; set; }
        public ICollection<ResultGpsPositionDto> GpsPositions { get; set; } = new List<ResultGpsPositionDto>();
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
