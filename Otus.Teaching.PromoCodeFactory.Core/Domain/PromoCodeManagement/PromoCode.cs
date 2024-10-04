using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime;
using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PromoCode
        : BaseEntity
    {
        [MaxLength(30)]
        public string Code { get; set; }

        [MaxLength(150)]
        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        [MaxLength(100)]
        public string PartnerName { get; set; }

        public Employee PartnerManager { get; set; }

        public Customer Customer { get; set; }

        public Preference Preference { get; set; }
    }
}