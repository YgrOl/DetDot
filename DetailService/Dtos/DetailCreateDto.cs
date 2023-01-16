using System.ComponentModel.DataAnnotations;

namespace DetailService.Dtos
{
    public class DetailCreateDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }
    }
}