using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.DAL.Models
{
    public class OfficialHoliday
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the name of the holiday")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the Date of the holiday")]
        public DateTime Date { get; set; }

    }
}
