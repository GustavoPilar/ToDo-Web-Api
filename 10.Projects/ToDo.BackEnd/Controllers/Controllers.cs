using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDo.BackEnd
{
    #region Controllers :: CategoryController, SeverityController, ToDoController

    #region CategoryController
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : ControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> Get()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll().ToList();

            if (categories is null)
            {
                return NotFound("Nenhum afazer foi encontrado"); 
            }

            List<CategoryDTO> categoriesDTO = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                CategoryDTO categoryDTO = new CategoryDTO()
                {
                    Id = category.Id,
                    Code = category.Code,
                    Description = category.Description
                };
                categoriesDTO.Add(categoryDTO);
            }

            return Ok(categoriesDTO);
        }

        [HttpGet("/{id:int}", Name = "GetNewCategory")]
        public ActionResult<CategoryDTO> GetById(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);

            if (category is null)
                return NotFound($"Categoria de Id {id} não encontrada");

            var categoryDTO = new CategoryDTO()
            {
                Id = category.Id,
                Code = category.Code,
                Description = category.Description,
            };

            return Ok(categoryDTO);
        }

        [HttpPost]
        public ActionResult<CategoryDTO> Post(CategoryDTO categoryDto)
        {
            if (categoryDto is null)
            {
                return BadRequest("A categoria não pode ser nula...");
            }

            Category category = new Category()
            {
                Id = categoryDto.Id,
                Code = categoryDto.Code,
                Description = categoryDto.Description
            };

            var createdCategory = _unitOfWork.CategoryRepository.Create(category);
            _unitOfWork.Commit();

            CategoryDTO NewCategoryDTO = new CategoryDTO()
            {
                Id = createdCategory.Id,
                Code = createdCategory.Code,
                Description = createdCategory.Description
            };

            return new CreatedAtRouteResult("GetNewCategory", new { id = NewCategoryDTO.Id }, NewCategoryDTO);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CategoryDTO> Put(int id, CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
            {
                return BadRequest("Id inválido...");
            }

            Category category = new Category()
            {
                Id = categoryDTO.Id,
                Code = categoryDTO.Code,
                Description = categoryDTO.Description
            };

            var updatedCategory = _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Commit();

            CategoryDTO updatedCategoryDTO = new CategoryDTO()
            {
                Id = categoryDTO.Id,
                Code = categoryDTO.Code,
                Description = categoryDTO.Description
            };

            return Ok(updatedCategoryDTO);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);

            if (category is null)
            {
                return BadRequest("Id inválido...");
            }

            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Commit();

            return Ok("Categoria deletada!");
        }
        #endregion
    }
    #endregion

    #region SeverityController
    [ApiController]
    [Route("[Controller]")]
    public class SeverityController : ControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor
        public SeverityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<Severity>> Get()
        {
            List<Severity> severities = _unitOfWork.SeverityRepository.GetAll().ToList();

            if (severities is null)
            {
                return NotFound("Nenhuma severidade foi encontrada...");
            }

            return Ok(severities);
        }

        [HttpGet("{id:int}", Name = "GetNewSeverity")]
        public ActionResult<Severity> GetById(int id)
        {
            Severity severity = _unitOfWork.SeverityRepository.GetById(id);

            if (severity is null)
            {
                return BadRequest("Nenhuma severidade foi encontrada...");
            }

            return Ok(severity);
        }

        [HttpPost]
        public ActionResult<Severity> Post(Severity severity)
        {
            if (severity == null)
            {
                return BadRequest("Severidade não pode ser nula...");
            }

            Severity severetyCreated = _unitOfWork.SeverityRepository.Create(severity);
            _unitOfWork.Commit();

            return new CreatedAtRouteResult("GetNewSeverity", new { id = severetyCreated.Id }, severetyCreated);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Severity> Put(int id, Severity severity)
        {
            if (id != severity.Id)
            {
                return BadRequest("Id inválido..");
            }

            Severity severityUpdated = _unitOfWork.SeverityRepository.Update(severity);
            _unitOfWork.Commit();

            return Ok(severityUpdated);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            Severity severity = _unitOfWork.SeverityRepository.GetById(id);

            if (severity is null)
            {
                return BadRequest("Id inválido...");
            }

            _unitOfWork.SeverityRepository.Delete(severity);
            _unitOfWork.Commit();

            return Ok("Severidade deletada!");
        }
        #endregion
    }
    #endregion

    #region ToDoController
    [ApiController]
    [Route("[Controller]")]
    public class ToDoController : ControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ToDoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Actions
        [HttpGet]
        [ServiceFilter(typeof(LoggingFilter))]
        public ActionResult<IEnumerable<ToDo>> Get()
        {
            List<ToDo> toDos = _unitOfWork.ToDoRepository.GetAll().ToList();

            if (toDos is null)
            {
                return BadRequest("Nenhum afazer encontrado...");
            }

            return Ok(toDos);
        }

        [HttpGet("{id:int}", Name = "GetNewToDo")]
        public ActionResult<ToDo> GetById(int id)
        {
            ToDo toDo = _unitOfWork.ToDoRepository.GetById(id);

            if (toDo is null)
            {
                return BadRequest("Nenhum afazer encontrado...");
            }

            return Ok(toDo);
        }

        [HttpGet("categoryId/{categoryId:int}")]
        public ActionResult<IEnumerable<ToDo>> GetByCategory(int categoryId)
        {
            List<ToDo> toDos = _unitOfWork.ToDoRepository.GetAllByCategory(categoryId).ToList();

            if (toDos is null)
            {
                return BadRequest("Nenhum afazer encontrado..");
            }

            return Ok(toDos);
        }

        [HttpPost]
        public ActionResult<ToDo> Post(ToDo toDo)
        {
            if (toDo is null)
            {
                return BadRequest("Afazer não pode ser nulo...");
            }

            ToDo toDoCreated = _unitOfWork.ToDoRepository.Create(toDo);

            return new CreatedAtRouteResult("GetNewToDo", new { id = toDoCreated.Id }, toDoCreated);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ToDo> Put(int id, ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return BadRequest("Id inválido...");
            }

            _unitOfWork.ToDoRepository.Update(toDo);

            return Ok(toDo);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            ToDo toDo = _unitOfWork.ToDoRepository.GetById(id);

            if (toDo is null)
            {
                return BadRequest("Id inválido...");
            }

            _unitOfWork.ToDoRepository.Delete(toDo);
            _unitOfWork.Commit();

            return Ok("Afazer deletado...");
        }
        #endregion
    }
    #endregion
    #endregion
}
