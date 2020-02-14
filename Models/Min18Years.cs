using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext _context)
        {
            var customer = (Customers)_context.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birth Date is required.");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : 
                new ValidationResult("Customer should be at least 18 years old to register for a membership.");
         
        }
    }
}