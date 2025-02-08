using System.ComponentModel.DataAnnotations;

namespace Service.Model
{
    public class User
    {
        // Additional uniqueness validation with database
        [Required]
        [StringLength(maximumLength:15, MinimumLength =5)]
        public string Login { get; set; }
        
    }
}
