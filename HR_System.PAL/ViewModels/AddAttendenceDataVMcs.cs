using System.ComponentModel.DataAnnotations;

namespace HR_System.PAL.ViewModels
{
    public class AddAttendenceDataVMcs
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
