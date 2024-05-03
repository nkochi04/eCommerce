﻿using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class OrderModel
    {
        [Key]
        public Guid ID{ get; set; }
        public Guid User_ID { get; set; }
        public Guid Supplier_ID { get; set; }
    }
}