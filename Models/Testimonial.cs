using System.ComponentModel.DataAnnotations;

namespace IT_Company_web.Models
{
    public class Testimonial
    {
        [Key]
            public int Id { get; set; }

            [Required]
            public string ClientName { get; set; }

            public string Company { get; set; }

            public string Review { get; set; }

            public int Rating { get; set; }
        }
    }


