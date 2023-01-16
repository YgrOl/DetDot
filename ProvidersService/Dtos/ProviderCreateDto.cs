using System.ComponentModel.DataAnnotations;

namespace ProvidersService.Dtos
{
    public class ProviderCreateDto
    {
        [Required]
        public string Made { get; set; }

        [Required]
        public string Factory { get; set; }
    }
}