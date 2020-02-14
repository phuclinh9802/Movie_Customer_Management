using Movie.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Dtos
{
    public class CustomerDto
    {
            public int Id { get; set; }

            [StringLength(255)]
            [Required]
            public string Name { get; set; }

            public bool IsSubscribedToNewsletter { get; set; }

            public MembershipTypeDto MembershipType { get; set; }

            public DateTime? BirthDate { get; set; }

            //Foreign Key

            public byte MembershipTypeId { get; set; }
    }
}