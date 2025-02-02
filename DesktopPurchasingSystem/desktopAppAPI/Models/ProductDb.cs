﻿using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class ProductDb
    {
        [Key]
        public Guid ID { get; set; }
        public Guid Seller_ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public byte[]? ImageData { get; set; }
    }
}
