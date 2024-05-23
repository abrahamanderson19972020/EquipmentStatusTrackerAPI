using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Equipment:IEntity
    {
        [Key]
        public int EquipmentId { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        [MaxLength(500)]
        public string Description { get; set; } =string.Empty;
    }
}
