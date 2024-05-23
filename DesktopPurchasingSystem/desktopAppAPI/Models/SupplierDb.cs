using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class SupplierDb
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Delivery_Period_In_Days { get; set; }
        public float Price_Per_Delivery { get; set; }
    }
}
