using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.Administration
{
    public class Employee
        : BaseEntity
    {
        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [EmailAddress]
        public string Email { get; set; }

        public Role Role { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}