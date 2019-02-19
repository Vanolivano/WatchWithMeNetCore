using System.Collections.Generic;

namespace BusinessLogicLayer.Domains
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<User> Users { get; set; }
    }
}