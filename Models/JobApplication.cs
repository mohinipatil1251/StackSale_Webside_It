using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Company_web.Models
{
    public class JobApplication
    {
        [Key]
            public int Id { get; set; }

            public int CareerId { get; set; }

            [Required]
            public string CandidateName { get; set; }

            [Required]
            public string Email { get; set; }

            public string Phone { get; set; }

            public string ResumePath { get; set; }

            public DateTime AppliedDate { get; set; } = DateTime.Now;

            public Career? Career { get; set; }
           public string? Role { get; set; }

          public string? Technology { get; set; }

          public string? Experience { get; set; }

          public string? CurrentCity { get; set; }

        [NotMapped]
        public IFormFile? ResumeFile { get; set; }
    }
    }


