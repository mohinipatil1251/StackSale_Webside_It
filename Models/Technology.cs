using System.ComponentModel.DataAnnotations;

namespace IT_Company_web.Models
{
    public class Technology
    
    {
        [Key]
            public int Id { get; set; }

            [Required]
            public string TechnologyName { get; set; }

            public string Description { get; set; }

            public string Image { get; set; }
        }
    }


