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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string PhoneNumber { get; set; } = string.Empty;

        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address? CustomerAddress { get; set; }
    }
}
