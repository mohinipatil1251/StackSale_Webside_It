using System.ComponentModel.DataAnnotations;

namespace IT_Company_web.Models
{
    public class Career
    {
        [Key]
            public int Id { get; set; }

            [Required]
            public string JobTitle { get; set; }

            public string Experience { get; set; }

            public string Location { get; set; }

            public string Salary { get; set; }

            public string Description { get; set; }
        }
    }


