﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Otus.Teaching.PromoCodeFactory.Core.Domain.Administration
{
    public class Role
        : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}