using System.ComponentModel.DataAnnotations;

namespace MarotiDemo.Models
{
    public class Department
    {
        [Key]
        public int deptid {  get; set; }

        public string deptname { get; set; }

        public string deptcode { get; set; }
    }
}
