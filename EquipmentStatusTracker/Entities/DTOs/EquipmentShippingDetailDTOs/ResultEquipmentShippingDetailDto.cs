using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EquipmentShippingDetailDTOs
{
    public class ResultEquipmentShippingDetailDto
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int SendingAddressId { get; set; }
        public string SendingStreet { get; set; } = string.Empty;
        public string SendingStreetNumber { get; set; } = string.Empty;
        public string SendingPostalCode { get; set; } = string.Empty;
        public string SendingCity { get; set; } = string.Empty;
        public string SendingState { get; set; } = string.Empty;
        public string SendingCountry { get; set; } = string.Empty;
        public int DestinationAddressId { get; set; }
        public string DestinationStreet { get; set; } = string.Empty;
        public string DestinationStreetNumber { get; set; } = string.Empty;
        public string DestinationPostalCode { get; set; } = string.Empty;
        public string DestinationCity { get; set; } = string.Empty;
        public string DestinationState { get; set; } = string.Empty;
        public string DestinationCountry { get; set; } = string.Empty;
        public string AdditionalNotes { get; set; } = string.Empty;
    }
}
