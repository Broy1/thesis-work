using FilterManagerPortal.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace FilterManagerPortal.Models.Viewmodels
{
    public class EmailSettingsViewModel
    {
        public bool SendEmail { get; set; }

        public bool SendEmailToSeller { get; set; }

        [Display(Name = "Message text:")]
        public string? EmailText { get; set; }
    }
}
