using System.ComponentModel.DataAnnotations;

namespace ToDo.BackEnd
{
    public class SeverityDTO
    {
        #region Fields
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Tamanho máximo de 80 caractéres")]
        public string? Code { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Tamanho máximo de 20 caractéres")]
        public string? Description { get; set; }
        #endregion
    }
}
