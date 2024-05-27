using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.GpsPositionDTOs
{
    public class CreateGpsPositionDto
    {
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public int EquipmentStatusId { get; set; }
    }
}
