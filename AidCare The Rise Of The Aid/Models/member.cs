using System.ComponentModel.DataAnnotations;

namespace AidCare_The_Rise_Of_The_Aid.Models
{
    public class member
    {
        public int memberId { get; set; }
        [Display(Name = "First Name"), Required, MaxLength(50)]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }
        [StringLength(30, MinimumLength = 3)]

        [Display(Name = "Last Name"), Required, MaxLength(50)]
        public string LastName { get; set; }
        [Display(Name = "Date Registered"),] 
        public DateTime DateTime { get; set; }
        public ICollection<memberevent> memberevent { get; set; }
        public ICollection<donation> donation { get; set; }
    }
}
