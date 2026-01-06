using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.BackEnd
{
    [Table("Severities")]
    public class Severity
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
