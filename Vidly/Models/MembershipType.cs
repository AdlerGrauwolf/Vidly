using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        // By convention every entityFramework class should have an Id, 
        // you can just named Id or in this case for example MemebershipTypeId

        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }
    }
}