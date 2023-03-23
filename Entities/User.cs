using System.ComponentModel.DataAnnotations;

namespace Livepl.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Username { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        public bool IsActive { get; set; } = false;

        public bool IsSuperUser { get; set; } = false;

        public DateTime? LastLogin { get; set; }

        public DateTime DateJoined { get; set; } = DateTime.Now;

        public DateTime? LastUpdated { get; set; } = DateTime.Now;
    }
}