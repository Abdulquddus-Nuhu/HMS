namespace Alansar.Core.Models.Requests
{
    public class CreateRoomRequest
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string? Type { get; set; }
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
    }
}
