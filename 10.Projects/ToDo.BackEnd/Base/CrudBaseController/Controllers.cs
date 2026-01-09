using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace ToDo.BackEnd
{
    #region CategoryController
    [ApiController]
    [Route("[Controller]")]
    public partial class CategoryController : CrudBaseController<Category, CategoryDTO>
    {
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
    #endregion

    #region SeverityController
    [ApiController]
    [Route("[Controller]")]
    public partial class SeverityController : CrudBaseController<Severity, SeverityDTO>
    {
        public SeverityController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
    #endregion

    #region ToDoController
    [ApiController]
    [Route("[Controller]")]
    public partial class ToDoController : CrudBaseController<ToDo, ToDoDTO>
    {
        public ToDoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
    #endregion
}
