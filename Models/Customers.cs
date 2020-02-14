using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [StringLength(255)][Required]
        public string Name { get; set; }

        [Display(Name= "Do you want to subscribe to the newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:MM-dd-yyyy}", ApplyFormatInEditMode=true)]
        [Display(Name = "Date of Birth")]
        [Min18Years]
        public DateTime? BirthDate { get; set; }

        public MembershipType MembershipType { get; set; }
        
        //Foreign Key
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}