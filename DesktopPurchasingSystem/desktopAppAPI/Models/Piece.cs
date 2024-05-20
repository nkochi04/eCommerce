using System.ComponentModel.DataAnnotations;

namespace DesktopAppAPI.Models
{
    public class Piece
    {
        [Key]
        public int Serial_Number { get; set; }
        public bool Sold { get; set; }

        public Guid? OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public Guid ProductId { get; set; }
        public virtual required Product Product { get; set; }
    }
}
