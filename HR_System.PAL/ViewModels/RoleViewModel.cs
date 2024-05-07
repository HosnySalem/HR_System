using System.ComponentModel.DataAnnotations;
namespace HR_System.PAL.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name="Group Name")]
        [Required(ErrorMessage = "Please enter group Name ")]
        public string Name { get; set; }
        
        
        public Dictionary<string, List<int>> Permissions { get; set; }

    }
}
