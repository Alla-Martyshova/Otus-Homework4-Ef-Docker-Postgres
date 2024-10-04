using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Customer
        :BaseEntity
    {
        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [EmailAddress]
        public string Email { get; set; }

        //public int Age { get; set; }

        //TODO: Списки Preferences и Promocodes 
        public IEnumerable<Preference> Preferences { get; set; }
        public IEnumerable<PromoCode> PromoCodes { get; set; }
    }
}