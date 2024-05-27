using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CustomerDTOs
{
    public class CreateCustomerDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string CustomerName { get; set; } = string.Empty;
        public int CommunicationDetailId { get; set; }
    }
}
