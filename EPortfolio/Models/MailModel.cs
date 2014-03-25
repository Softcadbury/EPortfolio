using System.ComponentModel.DataAnnotations;

namespace EPortfolio.Models
{
    public class MailModel
    {
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}