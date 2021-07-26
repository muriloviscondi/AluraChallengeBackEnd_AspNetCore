using System.ComponentModel.DataAnnotations;

namespace AluraChallenge.API.Models
{
    public class CreateVideoViewModel
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O título deve ter no máximo 50 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MaxLength(150, ErrorMessage = "A descrição deve ter no máximo 150 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A url é obrigatória.")]
        [MaxLength(150, ErrorMessage = "A url deve ter no máximo 150 caracteres.")]
        public string Url { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public string CategoryId { get; set; }
    }
}
