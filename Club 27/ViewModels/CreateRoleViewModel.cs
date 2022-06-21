using System.ComponentModel.DataAnnotations;

namespace Club_27.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set;}
    }
}
