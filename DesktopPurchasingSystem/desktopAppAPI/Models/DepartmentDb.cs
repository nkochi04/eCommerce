﻿using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class DepartmentDb
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Payment_Adress { get; set; } = string.Empty;
    }
}
