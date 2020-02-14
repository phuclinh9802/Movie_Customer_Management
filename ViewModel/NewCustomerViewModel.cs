using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customers Customers { get; set; }
    }
}