using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Entities
{
    [Table("Students")]  // Explicit table name
    public class Student
    {
        public Student()
        {
            // Use List<T> for navigation collections.
            // EF works with any ICollection<T> implementation.
            Enrollments = new List<Enrollment>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}