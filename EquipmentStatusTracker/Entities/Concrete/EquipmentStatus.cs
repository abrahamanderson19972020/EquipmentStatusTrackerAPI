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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("EquipmentShippingDetailId")]
        public EquipmentShippingDetail? EquipmentShippingDetail { get; set; } 
        public int EquipmentShippingDetailId { get; set; }

        public ICollection<GpsPosition> GpsPositions { get; set; } = new List<GpsPosition>();

        [ForeignKey("CustomerId ")]
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
