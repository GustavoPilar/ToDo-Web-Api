using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ToDo.BackEnd.Base.EntityBase
{
    public class EntityBase<T> : IEntityBase where T : class
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80, ErrorMessage = "Tamanho máximo de 80 caractéres")]
        public string? Code { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Tamanho máximo de 150 caractéres")]
        public string? Description { get; set; }

        public string ToString()
        {
            return $"{typeof(T).Name}: {Code} - {Description}";
        }
    }
}
