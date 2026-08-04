using System.ComponentModel.DataAnnotations;

namespace IT_Company_web.Models
{
    public class Client
    {
        [Key]
            public int Id { get; set; }

            [Required]
            public string ClientName { get; set; }

            public string CompanyName { get; set; }

            public string Logo { get; set; }

            public string Website { get; set; }
        }
    }


