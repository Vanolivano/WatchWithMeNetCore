namespace BusinessLogicLayer.Domains
{
    public class Room: DataAccessLayer.Entities.Room
    {
        public Room(DataAccessLayer.Entities.Room item)
        {
            Id = item.Id;
            Name = item.Name;
        }
        public Room(){}
    }
}