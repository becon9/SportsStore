using System.ComponentModel.DataAnnotations;

namespace SportsStore.WEB.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        // ReSharper disable once Mvc.TemplateNotResolved
        [UIHint("password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}