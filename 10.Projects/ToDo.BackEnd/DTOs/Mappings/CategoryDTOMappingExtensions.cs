namespace ToDo.BackEnd
{
    public static class CategoryDTOMappingExtensions
    {
        public static CategoryDTO? ToCategoryDTO(this Category category)
        {
            if (category is null)
                return null;
            
            return new CategoryDTO()
            {
                Id = category.Id,
                Code = category.Code,
                Description = category.Description
            };
        }

        public static Category? ToCategory (this CategoryDTO categoryDTO)
        {
            if (categoryDTO is null)
                return null;

            return new Category()
            {
                Id = categoryDTO.Id,
                Code = categoryDTO.Code,
                Description = categoryDTO.Description
            };
        }

        public static IEnumerable<CategoryDTO> ToCategoryDTOList(this IEnumerable<Category> categories)
        {
            if (categories is null || !categories.Any())
                return new List<CategoryDTO>();
        
            return categories.Select(category => new CategoryDTO()
            {
                Id = category.Id,
                Code = category.Code,
                Description = category.Description
            });
        }
    }
}
