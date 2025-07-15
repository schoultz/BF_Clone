using System.ComponentModel.DataAnnotations;

namespace BostadStockholm.Core.Entities
{
    public class User
    {
        public virtual Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }

        [Required]
        public virtual string PasswordHash { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string LastName { get; set; }

        [Phone]
        public virtual string PhoneNumber { get; set; }

        public virtual DateTime? DateOfBirth { get; set; }

        public virtual DateTime CreatedAt { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual IList<Application> Applications { get; set; } = new List<Application>();
    }
}