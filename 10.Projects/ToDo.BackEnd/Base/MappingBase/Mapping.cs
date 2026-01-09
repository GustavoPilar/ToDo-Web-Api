using AutoMapper;

namespace ToDo.BackEnd
{
    #region Entity :: CategoryProfile, CategoryRepository

    /// <summary>
    /// Profile: <see cref="Category"/>
    /// </summary>
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }

    /// <summary>
    /// Repository: <see cref="Category"/>
    /// </summary>
    public partial class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(ToDoContext context) : base(context)
        {
        }
    }
    #endregion

    #region Entity :: SeverityProfile, SevertityRepository
    /// <summary>
    /// Profile: <see cref="Severity"/>
    /// </summary>
    public class SeverityProfile : Profile
    {
        public SeverityProfile()
        {
            CreateMap<Severity, SeverityDTO>().ReverseMap();
        }
    }

    /// <summary>
    /// Repository: <see cref="Severity"/>
    /// </summary>
    public partial class SeverityRepository : RepositoryBase<Severity>
    {
        public SeverityRepository(ToDoContext context) : base(context)
        {
        }
    }
    #endregion

    #region Entity :: ToDoProfile, ToDoRepository
    /// <summary>
    /// Profile: <see cref="ToDo"/>
    /// </summary>
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDo, ToDoDTO>().ReverseMap();
        }
    }

    /// <summary>
    /// Repository: <see cref="ToDo"/>
    /// </summary>
    public partial class ToDoRepository : RepositoryBase<ToDo>
    {
        public ToDoRepository(ToDoContext context) : base(context)
        {
        }
    }
    #endregion
}
