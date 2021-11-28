using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Models;
using Dashboard.Services;
using Microsoft.AspNetCore.Identity;

namespace Dashboard.Areas.Identity.Data;

// Add profile data for application users by adding properties to the DashboardUser class
public class DashboardUser : IdentityUser
{
    public ICollection<OAuthSession> Sessions { get; set; }
}

