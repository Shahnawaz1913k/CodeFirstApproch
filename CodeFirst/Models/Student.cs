using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Column("FullName", TypeName = "varchar(100)")]
    public string FullName { get; set; } = string.Empty;

    [Column("StudentAge", TypeName = "int")]
    public int StudentAge { get; set; }

    [Column("StudentGender", TypeName = "varchar(20)")]
    public string StudentGender { get; set; } = string.Empty;

    [Column("StudentStandard", TypeName = "int")]
    public int StudentStandard { get; set; }
}

}