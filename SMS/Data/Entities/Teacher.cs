using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Entities
{
    [Table("Teachers")]  // Explicit table name
    public class Teacher
    {
        public Teacher()
        {
            // Use List<T> for navigation collections.
            // EF works with any ICollection<T> implementation.
            Courses = new List<Course>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}