namespace BusinessLogicLayer.Domains
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
        public Room Room { get; set; }
        public int? RoomId { get; set; }
    }
}