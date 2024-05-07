using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.DAL.ViewModelsForUpdate
{
    public class UpdateEmployeeAttendence
    {
        public int Id { get; set; }

        [Required]
        public DateTime AttendenceTime { get; set; }

        [Required]
        public DateTime LeavingTime { get; set; }
        [Required]

        public DateTime DayDate { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int? DepartmentId { get; set; }

    }
}
