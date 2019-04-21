using System.Collections.Generic;

using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerViewModel
    {
        public List<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}