﻿using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class SellerDb
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid AddressId { get; set; }
    }
}
