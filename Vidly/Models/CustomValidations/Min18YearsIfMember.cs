using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.CustomValidations
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == (byte)MembershipTypes.Undefined || customer.MembershipTypeId == (byte)MembershipTypes.PayAsYouGo)
                return ValidationResult.Success;

            if (!customer.Birthday.HasValue)
                return new ValidationResult("Birthday is required.");

            int age = calculateAge(customer.Birthday.Value);

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should at least 18 years old to subscribe to a membership.");
        }

        private int calculateAge(DateTime birthday)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(birthday.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000;

            return age;
        }
    }
}