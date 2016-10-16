
using System.ComponentModel.DataAnnotations;
namespace BusinessSite.Models
{
    public class Email
    {
        public int EmailID { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [EmailAddress(ErrorMessage="Niewłaściwy format email.")]
        public string EmailAddress { get; set; }
        public int? CalcAccessDateID { get; set; }

        public virtual CalcAccessDate CalcAccessDate { get; set; }
    }
}