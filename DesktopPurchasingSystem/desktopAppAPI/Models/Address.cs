﻿using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class Address
    {
        [Key]
        public Guid ID { get; set; }
        public int Number { get; set; }
        public string Road { get; set; } = string.Empty;
        public string Postalcode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public virtual ICollection<Seller>? Sellers { get; set; } = [];
    }
}