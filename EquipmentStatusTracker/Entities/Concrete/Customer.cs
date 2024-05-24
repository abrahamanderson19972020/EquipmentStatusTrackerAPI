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
    public class Customer:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string CustomerName { get; set; } = string.Empty;
        
        [ForeignKey("CommunicationDetailId")]
        public CommunicationDetail? CustomerCommunicationDetail { get; set; }
        public int CommunicationDetailId { get; set; }

    }
}
