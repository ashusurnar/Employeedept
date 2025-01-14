using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarotiDemo.Models
{
    public class Employee
    {
        [Key]
        public int empid { get; set; }

        public string empname { get; set; }

        public string city { get; set; }

        public int salary { get; set; }

        public int deptid { get; set; }
        [ForeignKey("deptid")]

        public Department Department { get; set; }


    }
}
