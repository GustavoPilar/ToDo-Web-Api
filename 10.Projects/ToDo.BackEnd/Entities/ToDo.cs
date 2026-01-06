using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDo.BackEnd
{
    [Table("ToDos")]
    public class ToDo
    {
        #region Fields
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
        #endregion

        #region Navegations
        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        
        [JsonIgnore]
        public Category? Category { get; set; }

        [Required]
        [ForeignKey("SeverityId")]
        public int SeverityId { get; set; }
        
        [JsonIgnore]
        public Severity? Severity { get; set; }
        #endregion
    }
}
