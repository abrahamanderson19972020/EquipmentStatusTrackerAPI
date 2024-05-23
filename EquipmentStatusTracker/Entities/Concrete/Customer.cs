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
        [Required]
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int CommunicationDetailId { get; set; }
        [ForeignKey(nameof(CommunicationDetailId))]
        public CommunicationDetail CustomerCommunicationDetail { get; set; } = new CommunicationDetail();

    }
}
