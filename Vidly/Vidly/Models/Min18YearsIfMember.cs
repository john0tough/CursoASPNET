﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == 1 || customer.MembershipTypeId == 0 )
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null) {
                return new ValidationResult("Birthday is Required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return age < 18 
                ? new ValidationResult("Customer should be at least 18 years old to go on a membership ") 
                : ValidationResult.Success;
        }
    }
}