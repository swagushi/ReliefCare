using System.ComponentModel.DataAnnotations;

namespace AidCare_The_Rise_Of_The_Aid.Models
{
    public class protest
    {
        public int protestId { get; set; }
        [Display(Name = "Event Name"), Required, MaxLength(50)]
        [StringLength(30, MinimumLength = 10)]
        public string ProtestName { get; set;}
        [Display(Name = "Event Location"), Required, MaxLength(50)]
        [StringLength(30, MinimumLength = 10)]
        public string ProtestLocation { get; set; }
        
        [Display(Name = "Event Date and Time")]
        public DateTime ProtestDate { get; set; }
        public ICollection<memberevent> memberevent { get; set; }
    }
}
