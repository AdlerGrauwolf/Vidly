using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public DateTime? Birthday { get; set; }

        public bool IssubscribedToNewsLatter { get; set; }



        // Navigation property, put first the object and then the id property for good table creation
        public MembershipType MembershipType { get; set; }
        // To add a property as foreign key by convention we named objectType+id and with this
        // EntityFrameWorks understand that it's a FK
        public byte MembershipTypeId { get; set; }
    }
}