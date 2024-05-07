using HR_System.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace HR_System.PAL.ViewModels
{
    public class AppUserVM
    {

        [Required]
        public string fullName { get; set; }

        [Required]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "من فضلك ادخل اسم بريد صالح")]
        public string email { get; set; }

        public List<CheckboxVM> Roles { get; set; }

    }
}
