namespace AidCare_The_Rise_Of_The_Aid.Models
{
    public class protest
    {
        public int protestId { get; set; }
        public string ProtestName { get; set;}
        public string ProtestLocation { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<memberevent> memberevent { get; set; }
    }
}
