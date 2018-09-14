using System.Collections.Generic;

using Vidly.Models;

namespace Vidly.ViewModel
{
    public class NewClassViewModel
    {
        public List<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}