using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EquipmentStatus
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(EquipmentShippingDetail))]
        public int EquipmentShippingDetailId { get; set; }
        public EquipmentShippingDetail EquipmentShippingDetail { get; set; } = new EquipmentShippingDetail(); // Navigation property

        [Required]
        public List<GpsPosition> GpsPositions { get; set; } = new List<GpsPosition>();

        [ForeignKey(nameof(Customer))]
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer(); // Navigation property
    }
}
