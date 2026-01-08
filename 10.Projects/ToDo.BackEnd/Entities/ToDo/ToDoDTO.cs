using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.BackEnd
{
    public class ToDoDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Tamanho máximo de 80 caractéres")]
        public string? Code { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Tamanho máximo de 150 caractéres")]
        public string? Description { get; set; }

        [Required]
        public bool AlreadyDone { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        public DateTime? FinishDateTime { get; set; }

        [Required]
        [ForeignKey("SeverityId")]
        public int SeverityId { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    }
}
