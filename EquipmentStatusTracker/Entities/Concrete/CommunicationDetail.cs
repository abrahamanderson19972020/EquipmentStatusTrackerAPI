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
    public class CommunicationDetail:IEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public Address CustomerAddress { get; set; } = new Address();
    }
}
