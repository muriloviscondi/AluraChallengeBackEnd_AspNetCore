using System.ComponentModel.DataAnnotations;

namespace AluraChallenge.API.Models
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O título deve ter no máximo 50 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A cor é obrigatória.")]
        [MaxLength(50, ErrorMessage = "A cor deve ter no máximo 50 caracteres.")]
        public string Color { get; set; }
    }
}
