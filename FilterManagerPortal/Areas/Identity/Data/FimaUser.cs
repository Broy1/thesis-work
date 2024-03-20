using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilterManagerPortal.Models;
using Microsoft.AspNetCore.Identity;

namespace FilterManagerPortal.Areas.Identity.Data;

public class FimaUser : IdentityUser
{
    public bool IsUserAdmin { get; set; }

    public bool IsVerified { get; set; }

    public bool SendNotificationEmailToUser { get; set; }

    public bool SendEmailToSeller { get; set; }

    public bool UseEmailTemplate { get; set; }

    public string? EmailText { get; set; }

    public virtual ICollection<Filter>? UserFilters { get; set; }
}

