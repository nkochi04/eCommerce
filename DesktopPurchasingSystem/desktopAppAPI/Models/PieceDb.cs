using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class PieceDb
    {
        [Key]
        public int Serial_Number { get; set; }
        public bool Sold { get; set; }

        public Guid? OrderId { get; set; }

        public Guid ProductId { get; set; }
    }
}
