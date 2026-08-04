using System.ComponentModel.DataAnnotations;

namespace IT_Company_web.Models
{
    public class Project
    {


        [Key]
            public int Id { get; set; }

            [Required]
            public string ProjectName { get; set; }

            public string ClientName { get; set; }

            public string Description { get; set; }

            public string Technology { get; set; }

            public string Image { get; set; }
        }
    }


