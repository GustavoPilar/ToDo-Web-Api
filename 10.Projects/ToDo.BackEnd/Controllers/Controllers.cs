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
        private readonly ICategoryRepository _repository;
        #endregion

        #region Constructor
        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        } 
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _repository.GetCategories().ToList();
            return Ok(categories);
        }

        [HttpGet("/{id:int}", Name = "GetNewCategory")]
        public ActionResult<Category> GetById(int id)
        {
            var category = _repository.GetCategoryById(id);

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

            var createdCategory = _repository.Create(category);

            return new CreatedAtRouteResult("GetNewCategory", new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Category> Put(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest("Id inválido...");
            }

            var updatedCategory = _repository.Update(category);

            return Ok(updatedCategory);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            Category category = _repository.Delete(id);

            if (category is null)
            {
                return BadRequest("Id inválido...");
            }

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
        private readonly ToDoContext _context;
        #endregion

        #region Constructor
        public SeverityController(ToDoContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Severity>>> Get()
        {
            List<Severity> severities = await _context.Severities.AsNoTracking().ToListAsync();

            if (severities is null)
            {
                return NotFound("Nenhuma severidade foi encontrada...");
            }

            return Ok(severities);
        }

        [HttpGet("{id:int}", Name = "GetNewSeverity")]
        public async Task<ActionResult<Severity>> GetById(int id)
        {
            Severity severity = await _context.Severities.AsNoTracking().FirstOrDefaultAsync(se => se.Id == id);

            if (severity is null)
            {
                return BadRequest("Nenhuma severidade foi encontrada...");
            }

            return Ok(severity);
        }

        [HttpPost]
        public async Task<ActionResult<Severity>> Post(Severity severity)
        {
            if (severity == null)
            {
                return BadRequest("Severidade não pode ser nula...");
            }

            await _context.Severities.AddAsync(severity);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetNewSeverity", new { id = severity.Id }, severity);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Severity>> Put(int id, Severity severity)
        {
            if (id != severity.Id)
            {
                return BadRequest("Id inválido..");
            }

            _context.Entry(severity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(severity);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            Severity severity = await _context.Severities.FirstOrDefaultAsync(s => s.Id == id);

            if (severity is null)
            {
                return BadRequest("Id inválido...");
            }

            _context.Severities.Remove(severity);
            await _context.SaveChangesAsync();

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
        private readonly IRepositoryBase<ToDo> _repository;
        private readonly IToDoRepository _ToDoRepository;
        #endregion

        #region Constructor
        public ToDoController(IRepositoryBase<ToDo> repository, IToDoRepository toDoRepository)
        {
            _repository = repository;
            _ToDoRepository = toDoRepository;
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
            ToDo toDo = _ToDoRepository.GetById(id);

            if (toDo is null)
            {
                return BadRequest("Nenhum afazer encontrado...");
            }

            return Ok(toDo);
        }

        [HttpGet("categoryId/{categoryId:int}")]
        public ActionResult<IEnumerable<ToDo>> GetByCategory(int categoryId)
        {
            List<ToDo> toDos = _ToDoRepository.GetAllByCategory(categoryId).ToList();

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
            ToDo toDo = _ToDoRepository.GetById(id);

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
