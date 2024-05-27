using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CommunicationDetailDTOs
{
    public class CreateCommunicationDetailDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string PhoneNumber { get; set; } = string.Empty;
        public int AddressId { get; set; }
    }
}
