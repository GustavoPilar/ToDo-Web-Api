using System.ComponentModel.DataAnnotations;

namespace ToDo.BackEnd
{
    public class CategoryDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Tamanho máximo de 80 caractéres")]
        public string? Code { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Tamanho máximo de 150 caractéres")]
        public string? Description { get; set; }

    }
}
