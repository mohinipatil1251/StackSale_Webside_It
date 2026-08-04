using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Company_web.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ServiceName { get; set; }

        public string Description { get; set; }

        public string? Image { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}

