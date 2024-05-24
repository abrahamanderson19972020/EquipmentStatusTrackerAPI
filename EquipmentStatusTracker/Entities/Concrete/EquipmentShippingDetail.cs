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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [ForeignKey("EquipmentId")]
        public Equipment? Equipment { get; set; } 
        public int EquipmentId { get; set; }


        public int Quantity { get; set; }

        [ForeignKey("SendingAddressId")]
        public Address? SendingAddress { get; set; } 
        public int SendingAddressId { get; set; }

        [ForeignKey("DestinationAddressId")]
        public Address? DestinationAddress { get; set; } 
        public int DestinationAddressId { get; set; }

        [MaxLength(255)]
        public string? AdditionalNotes { get; set; }
    }
}
