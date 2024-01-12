using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Project.MVCUI.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} zorunludur")]
        [EmailAddress(ErrorMessage = "Doğru formatta {0} giriniz")]
        [StringLength(100, MinimumLength = 7, ErrorMessage = "{0}, {2} ile {1} karakter arasında olabilir")]
        [DataType(DataType.Text)]
        public string Email { get; set; } = null!;

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} zorunludur")]
        [StringLength(80, MinimumLength = 6, ErrorMessage = "{0}, {2} ile {1} karakter arasında olabilir")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
