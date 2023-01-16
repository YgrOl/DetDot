
using System.ComponentModel.DataAnnotations;
namespace DetailService.Models
{
    public class Detail
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }
    }
}