namespace AidCare_The_Rise_Of_The_Aid.Models
{
    public class donation
    {
        public int DonationId { get; set; }
        public string DonationDescription { get; set; }
        public int DonationAmount { get; set; }
        public ICollection <member> member { get; set; }
    }
}
