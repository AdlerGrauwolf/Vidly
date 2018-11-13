using System;
using System.ComponentModel.DataAnnotations;

using Vidly.Models.CustomValidations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YearsIfMember]
        public DateTime? Birthday { get; set; }

        public bool IsSubscribedToNewsLatter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}