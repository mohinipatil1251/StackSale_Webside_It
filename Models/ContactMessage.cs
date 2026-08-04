using System.ComponentModel.DataAnnotations;

namespace IT_Company_web.Models
{
    public class ContactMessage
    {

        [Key]
            public int Id { get; set; }

            [Required]
            public string FullName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            public string Phone { get; set; }

            public string Subject { get; set; }

            [Required]
            public string Message { get; set; }

            public DateTime CreatedDate { get; set; } = DateTime.Now;
        }
    }


