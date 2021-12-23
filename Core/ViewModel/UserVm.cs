using System.ComponentModel.DataAnnotations;

namespace PowerAutomate.Core.ViewModel
{
    public class UserVm
    {
        [Required(ErrorMessage = "Escriba su Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Escriba su Password")]
        public string Password { get; set; }
        
    }
}