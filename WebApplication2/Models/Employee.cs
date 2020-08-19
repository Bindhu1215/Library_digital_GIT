using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Password { get; set; }

        public DateTime Date_of_birth { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public String EmailID { get; set; }

        public Int64 Mobile_NO { get; set; }
        public DateTime Registration_Date { get; set; }
        public String Address { get; set; }
        public String Role { get; set; }

    }
}
