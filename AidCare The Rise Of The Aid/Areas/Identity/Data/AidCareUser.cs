using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AidCare_The_Rise_Of_The_Aid.Areas.Identity.Data;

// Add profile data for application users by adding properties to the AidCareUser class
public class AidCareUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

