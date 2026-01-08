using AutoMapper;
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
            List<Category> categories = _unitOfWork.CategoryRepository.GetAll().ToList();

            if (categories is null)
            {
                return NotFound("Nenhum afazer foi encontrado"); 
            }

            List<CategoryDTO> categoriesDTO = categories.ToCategoryDTOList().ToList();

            return Ok(categoriesDTO);
        }

        [HttpGet("/{id:int}", Name = "GetNewCategory")]
        public ActionResult<CategoryDTO> GetById(int id)
        {
            Category category = _unitOfWork.CategoryRepository.GetById(id);

            if (category is null)
                return NotFound($"Categoria de Id {id} não encontrada");

            CategoryDTO categoryDTO = category.ToCategoryDTO();

            return Ok(categoryDTO);
        }

        [HttpPost]
        public ActionResult<CategoryDTO> Post(CategoryDTO categoryDto)
        {
            if (categoryDto is null)
            {
                return BadRequest("A categoria não pode ser nula...");
            }

            Category category = categoryDto.ToCategory();

            Category createdCategory = _unitOfWork.CategoryRepository.Create(category);
            _unitOfWork.Commit();

            CategoryDTO NewCategoryDTO = category.ToCategoryDTO();

            return new CreatedAtRouteResult("GetNewCategory", new { id = NewCategoryDTO.Id }, NewCategoryDTO);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CategoryDTO> Put(int id, CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
            {
                return BadRequest("Id inválido...");
            }

            Category category = categoryDTO.ToCategory();

            Category updatedCategory = _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Commit();

            CategoryDTO updatedCategoryDTO = category.ToCategoryDTO();

            return Ok(updatedCategoryDTO);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            Category category = _unitOfWork.CategoryRepository.GetById(id);

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
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ToDoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Actions
        [HttpGet]
        [ServiceFilter(typeof(LoggingFilter))]
        public ActionResult<IEnumerable<ToDoDTO>> Get()
        {
            List<ToDo> toDos = _unitOfWork.ToDoRepository.GetAll().ToList();

            if (toDos is null)
            {
                return BadRequest("Nenhum afazer encontrado...");
            }

            List<ToDoDTO> toDoDtos = _mapper.Map<IEnumerable<ToDoDTO>>(toDos).ToList(); 
             
            return Ok(toDoDtos);
        }

        [HttpGet("{id:int}", Name = "GetNewToDo")]
        public ActionResult<ToDoDTO> GetById(int id)
        {
            ToDo toDo = _unitOfWork.ToDoRepository.GetById(id);

            if (toDo is null)
            {
                return BadRequest("Nenhum afazer encontrado...");
            }

            ToDoDTO toDoDTO = _mapper.Map<ToDoDTO>(toDo);

            return Ok(toDoDTO);
        }

        [HttpGet("categoryId/{categoryId:int}")]
        public ActionResult<IEnumerable<ToDoDTO>> GetByCategory(int categoryId)
        {
            List<ToDo> toDos = _unitOfWork.ToDoRepository.GetAllByCategory(categoryId).ToList();

            if (toDos is null)
            {
                return BadRequest("Nenhum afazer encontrado..");
            }

            List<ToDoDTO> toDosDTO = _mapper.Map<IEnumerable<ToDoDTO>>(toDos).ToList();

            return Ok(toDosDTO);
        }

        [HttpPost]
        public ActionResult<ToDoDTO> Post(ToDoDTO toDoDTO)
        {
            if (toDoDTO is null)
            {
                return BadRequest("Afazer não pode ser nulo...");
            }

            ToDo toDoCreated = _unitOfWork.ToDoRepository.Create(_mapper.Map<ToDo>(toDoDTO));
            ToDoDTO CreatedtoDoDTO = _mapper.Map<ToDoDTO>(toDoCreated);

            return new CreatedAtRouteResult("GetNewToDo", new { id = CreatedtoDoDTO.Id }, CreatedtoDoDTO);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ToDoDTO> Put(int id, ToDoDTO toDoDTO)
        {
            if (id != toDoDTO.Id)
            {
                return BadRequest("Id inválido...");
            }

            ToDo toDo = _mapper.Map<ToDo>(toDoDTO);
            _unitOfWork.ToDoRepository.Update(toDo);
            ToDoDTO updatedToDoDTO = _mapper.Map<ToDoDTO>(toDo);

            return Ok(updatedToDoDTO);
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
