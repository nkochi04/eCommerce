using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class PieceModel
    {
        [Key]
        public int Serial_Number { get; set; }
        public Guid Product_ID { get; set; }
        public bool Sold { get; set; }
    }
}
