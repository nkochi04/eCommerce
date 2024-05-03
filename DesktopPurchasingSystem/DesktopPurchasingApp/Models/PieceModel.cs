using System.ComponentModel.DataAnnotations;

namespace DesktopPurchasingApp.Models
{
    public class PieceModel
    {
        [Key]
        public int Serial_Number { get; set; }
        public Guid Product_ID { get; set; }
        public bool Sold { get; set; }
    }
}
