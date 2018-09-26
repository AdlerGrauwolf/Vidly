using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Vidly.Models.CustomValidations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [DisplayName("Day of Birth")]
        [Min18YearsIfMember]
        public DateTime? Birthday { get; set; }

        public bool IssubscribedToNewsLatter { get; set; }

        // Navigation property, put first the object and then the id property for good table creation
        public MembershipType MembershipType { get; set; }

        // To add a property as foreign key by convention we named objectType+id and with this
        // EntityFrameWorks understand that it's a FK
        [DisplayName("Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}