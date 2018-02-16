using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) (validationContext.ObjectInstance);

            if(customer.MembershipTypeId == (byte) MembershipType.MembershipTypeValidation.Unknow 
               || customer.MembershipTypeId == (byte) MembershipType.MembershipTypeValidation.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("The birthdate is required.");

            var age = DateTime.Now.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("You need 18 years old at least to have a membership");
        }
    }
}