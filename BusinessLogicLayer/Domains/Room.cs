using System.Collections.Generic;

namespace BusinessLogicLayer.Domains
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        
        public List<Customer> Users { get; set; }
    }
}