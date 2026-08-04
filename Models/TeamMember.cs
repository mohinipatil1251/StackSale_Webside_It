using System.ComponentModel.DataAnnotations;

namespace IT_Company_web.Models
{
    public class TeamMember
    {

        [Key]
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            public string Designation { get; set; }

            public string Email { get; set; }

            public string Image { get; set; }

            public string LinkedIn { get; set; }
        }
    }


