﻿using System.ComponentModel.DataAnnotations;

namespace DesktopPurchasingApp.Models
{
    public class ProductModel
    {
        [Key]
        public Guid ID { get; set; }
        public Guid Seller_ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public int PiecesAvailable { get; set; }
    }
}