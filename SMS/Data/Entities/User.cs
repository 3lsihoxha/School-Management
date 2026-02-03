using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Entities
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            // Use List<T> for navigation collections.
            // EF works with any ICollection<T> implementation.
            Teachers = new List<Teacher>();
            Students = new List<Student>();
        }

        public int Id { get; set; }
        // Required by the assignment UI: shown next to Id in the Admin dashboard
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
