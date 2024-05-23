using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Address:IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string Street { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string StreetNumber { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string PostalCode { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty ;
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string State { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Country { get; set; } = string.Empty;

    }
}
