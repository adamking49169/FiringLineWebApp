using System.ComponentModel.DataAnnotations;

namespace FiringLineWebApp.Models
{
    public class SiteItem
    {
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Title { get; set; } = "";

        [MaxLength(400)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }
}
