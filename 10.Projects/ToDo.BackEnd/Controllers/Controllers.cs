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
        private readonly IRepositoryBase<Category> _repository;
        #endregion

        #region Constructor
        public CategoryController(IRepositoryBase<Category> repository)
        {
            _repository = repository;
        } 
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _repository.GetAll().ToList();
            return Ok(categories);
        }

        [HttpGet("/{id:int}", Name = "GetNewCategory")]
        public ActionResult<Category> GetById(int id)
        {
            Category category = _repository.GetByProp(x => x.Id == id);

            if (category is null)
                return NotFound($"Categoria de Id {id} não encontrada");

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Category> Post(Category category)
        {
            if (category is null)
            {
                return BadRequest("A categoria não pode ser nula...");
            }

            Category createdCategory = _repository.Create(category);

            return new CreatedAtRouteResult("GetNewCategory", new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Category> Put(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest("Id inválido...");
            }

            Category updatedCategory = _repository.Update(category);

            return Ok(updatedCategory);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            Category category = _repository.GetByProp(x => x.Id == id);

            if (category is null)
            {
                return BadRequest("Id inválido...");
            }

            _repository.Delete(category);

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
        private readonly IRepositoryBase<Severity> _repository;
        #endregion

        #region Constructor
        public SeverityController(IRepositoryBase<Severity> repository)
        {
            _repository = repository;
        }
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<Severity>> Get()
        {
            List<Severity> severities = _repository.GetAll().ToList();

            if (severities is null)
            {
                return NotFound("Nenhuma severidade foi encontrada...");
            }

            return Ok(severities);
        }

        [HttpGet("{id:int}", Name = "GetNewSeverity")]
        public ActionResult<Severity> GetById(int id)
        {
            Severity severity = _repository.GetByProp(se => se.Id == id);

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

            Severity severetyCreated = _repository.Create(severity);

            return new CreatedAtRouteResult("GetNewSeverity", new { id = severetyCreated.Id }, severetyCreated);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Severity> Put(int id, Severity severity)
        {
            if (id != severity.Id)
            {
                return BadRequest("Id inválido..");
            }

            Severity severityUpdated = _repository.Update(severity);
            return Ok(severityUpdated);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            Severity severity = _repository.GetByProp(x => x.Id == id);

            if (severity is null)
            {
                return BadRequest("Id inválido...");
            }

            _repository.Delete(severity);

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
        private readonly IToDoRepository _toDoRepository;
        private readonly IRepositoryBase<ToDo> _repository;
        #endregion

        #region Constructor
        public ToDoController(IRepositoryBase<ToDo> repository, IToDoRepository toDoRepository)
        {
            _repository = repository;
            _toDoRepository = toDoRepository;
        }
        #endregion

        #region Actions
        [HttpGet]
        [ServiceFilter(typeof(LoggingFilter))]
        public ActionResult<IEnumerable<ToDo>> Get()
        {
            List<ToDo> toDos = _repository.GetAll().ToList();

            if (toDos is null)
            {
                return BadRequest("Nenhum afazer encontrado...");
            }

            return Ok(toDos);
        }

        [HttpGet("{id:int}", Name = "GetNewToDo")]
        public ActionResult<ToDo> GetById(int id)
        {
            ToDo toDo = _repository.GetByProp(x => x.Id == id);

            if (toDo is null)
            {
                return BadRequest("Nenhum afazer encontrado...");
            }

            return Ok(toDo);
        }

        [HttpGet("categoryId/{categoryId:int}")]
        public ActionResult<IEnumerable<ToDo>> GetByCategory(int categoryId)
        {
            List<ToDo> toDos = _toDoRepository.GetAllByCategory(categoryId).ToList();

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

            ToDo toDoCreated = _repository.Create(toDo);

            return new CreatedAtRouteResult("GetNewToDo", new { id = toDoCreated.Id }, toDoCreated);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ToDo> Put(int id, ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return BadRequest("Id inválido...");
            }

            _repository.Update(toDo);

            return Ok(toDo);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<ToDo> Delete(int id)
        {
            ToDo toDo = _repository.GetByProp(x => x.Id == id);

            if (toDo is null)
            {
                return BadRequest("Id inválido...");
            }

            ToDo toDoDeleted = _repository.Delete(toDo);

            return Ok(toDoDeleted);
        }
        #endregion
    }
    #endregion
    #endregion
}
