using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Column("FullName", TypeName = "varrchar(100)")]
        public string Name { get; set; }
        [Column("StudentAge", TypeName = "int" )]
        public int Age { get; set; }
    }
}