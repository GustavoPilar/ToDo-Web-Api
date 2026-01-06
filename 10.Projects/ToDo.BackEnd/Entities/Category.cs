using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDo.BackEnd
{
    [Table("Categories")]
    public class Category
    {
        #region Constructor
        public Category()
        {
            ToDos = new List<ToDo>();
        }
        #endregion

        #region Fields
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Tamanho máximo de 80 caractéres")]
        public string? Code { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Tamanho máximo de 150 caractéres")]
        public string? Description { get; set; }
        #endregion

        #region Navigation
        public ICollection<ToDo> ToDos { get; set; }
        #endregion
    }
}
