using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EquipmentShippingDetail:IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Equipment))]
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; } = new Equipment();

        public int Quantity { get; set; }

        [Required]
        public int SendingAddressId { get; set; }
        [ForeignKey(nameof(SendingAddressId))]
        public Address SendingAddress { get; set; } = new Address();

        [Required]
        public int DestinationAddressId { get; set; }
        [ForeignKey(nameof(DestinationAddressId))]
        public Address DestinationAddress { get; set; } = new Address();

        [MaxLength(255)]
        public string AdditionalNotes { get; set; } = string.Empty;
    }
}
