using System.ComponentModel.DataAnnotations;

namespace ShopSphereBackend.Model.VendorModel
{
    public class EmployeeSignup
    {

        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        public string Role { get; set; } = "Staff";

        public bool IsActive { get; set; } = true;

        public DateTime? LastLogin { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }


}
