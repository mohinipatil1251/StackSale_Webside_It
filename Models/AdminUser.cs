using System.ComponentModel.DataAnnotations;

namespace IT_Company_web.Models
{
    public class AdminUser
    {
        [Key]
            public int Id { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }

            public string Role { get; set; }
        }
    }


