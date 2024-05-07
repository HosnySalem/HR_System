using HR_System.DAL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [RegularExpression(@"^\d{14}$", ErrorMessage = "The national number must be 14 numbers")]
        [Required]
        [UniqueNationalId]
        public string NationalID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^01[0125]\d{8}$", ErrorMessage = "Please enter a valid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "DATE")]
        [AgeGreaterThanOrEqual20]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "DATE")]
        // هنا في validation في حالة ان تاريخ التعاقد أقل من تاريخ إنشاء الشركة
        public DateTime DateOfContract { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid salary")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime AttendanceTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }

        public List<Attendence>? Attendences { get; set; }
      
        public Department? Department { get; set; }

        [ForeignKey("Department")]
        [Required]
        public int? DepartmentId { get; set; }


        public bool IsDelete { get; set; } = false;
        public List<EmployeesSalaries>? Salaries { get; set; }
    }
}
