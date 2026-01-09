using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ToDo.BackEnd.Base.EntityBase;

namespace ToDo.BackEnd
{
    #region Entity :: Category, CategoryDTO
    /// <summary>
    /// Entity: <see cref="Category"/>
    /// </summary>
    public class Category : EntityBase<Category>
    {
        #region Constructor
        public Category()
        {
            ToDos = new List<ToDo>();
        }
        #endregion

        #region Navigation
        [JsonIgnore]
        public ICollection<ToDo> ToDos { get; set; }
        #endregion
    }

    /// <summary>
    /// Data Transfer Object: <see cref="CategoryDTO"/>
    /// </summary>
    public class CategoryDTO : EntityBase<CategoryDTO>
    {
        public CategoryDTO() { }
    }
    #endregion

    #region Entity :: Severity, SeverityDTO
    /// <summary>
    /// Entity: <see cref="Severity"/>
    /// </summary>
    public class Severity : EntityBase<Severity>
    {
        public Severity() { }
    }
    
    /// <summary>
    /// Data Transfer Object: <see cref="SeverityDTO"/>
    /// </summary>
    public class SeverityDTO : EntityBase<SeverityDTO>
    {
        public SeverityDTO() { }
    }
    #endregion

    #region Entity :: ToDo, ToDoDTO
    /// <summary>
    /// Entity: <see cref="ToDo"/>
    /// </summary>
    public class ToDo : EntityBase<ToDo>
    {
        #region Constructor
        public ToDo() { }
        #endregion

        #region Fields
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

    /// <summary>
    /// Data Transfer Object: <see cref="ToDoDTO" />
    /// </summary>
    public class ToDoDTO : EntityBase<ToDoDTO>
    {
        #region Constructor
        public ToDoDTO() { }
        #endregion

        #region Fields
        [Required]
        public bool AlreadyDone { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        public DateTime? FinishDateTime { get; set; }
        #endregion

        #region Navigations
        [Required]
        [ForeignKey("SeverityId")]
        public int SeverityId { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        #endregion
    }
    #endregion
}
