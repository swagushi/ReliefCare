namespace AidCare_The_Rise_Of_The_Aid.Models
{
    public class memberevent
    {
        public int membereventId { get; set; }
        public string membereventName { get; set; }
        public int memberId { get; set; }
        public int protestId { get; set; }
        public member member { get; set; }
        public protest protest { get; set; }
    }
}
