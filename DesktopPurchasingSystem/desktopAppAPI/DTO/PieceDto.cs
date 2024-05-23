namespace DesktopAppAPI.DTO
{
    public class PieceDto
    {
        public int Serial_Number { get; set; }
        public bool Sold { get; set; }

        public Guid? OrderId { get; set; }
        public Guid ProductId { get; set; }
    }
}
