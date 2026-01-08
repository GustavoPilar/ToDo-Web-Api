using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDo.BackEnd
{
    #region Controllers :: CategoryController, SeverityController, ToDoController

    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : CrudBaseController<Category, CategoryDTO>
    {
        public CategoryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

    //#region CategoryController
    //[ApiController]
    //[Route("[Controller]")]
    //public class CategoryController : ControllerBase
    //{
    //    #region Fields
    //    private readonly IUnitOfWork _unitOfWork;
    //    #endregion

    //    #region Constructor
    //    public CategoryController(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }
    //    #endregion

    //    #region Actions
    //    [HttpGet]
    //    public ActionResult<IEnumerable<CategoryDTO>> Get()
    //    {
    //        IEnumerable<CategoryDTO> categories = _unitOfWork.CategoryRepository.GetAll().ToList().ToCategoryDTOListCast();

    //        if (categories is null)
    //        {
    //            return NotFound("Nenhum afazer foi encontrado");
    //        }

    //        return Ok(categories.ToList());
    //    }

    //    [HttpGet("/{id:int}", Name = "GetNewCategory")]
    //    public ActionResult<CategoryDTO> GetById(int id)
    //    {
    //        Category category = _unitOfWork.CategoryRepository.GetById(id);

    //        if (category is null)
    //            return NotFound($"Categoria de Id {id} não encontrada");

    //        return Ok(category.ToCategoryDTOCast());
    //    }

    //    [HttpPost]
    //    public ActionResult<CategoryDTO> Post(CategoryDTO categoryDTO)
    //    {
    //        if (categoryDTO is null)
    //        {
    //            return BadRequest("A categoria não pode ser nula...");
    //        }

    //        Category createdCategory = _unitOfWork.CategoryRepository.Create(categoryDTO.ToCategoryCast());
    //        _unitOfWork.Commit();

    //        CategoryDTO NewCategoryDTO = createdCategory.ToCategoryDTOCast();

    //        return new CreatedAtRouteResult("GetNewCategory", new { id = NewCategoryDTO.Id }, NewCategoryDTO);
    //    }

    //    [HttpPut("{id:int}")]
    //    public ActionResult<CategoryDTO> Put(int id, CategoryDTO categoryDTO)
    //    {
    //        if (id != categoryDTO.Id)
    //        {
    //            return BadRequest("Id inválido...");
    //        }

    //        Category updatedCategory = _unitOfWork.CategoryRepository.Update(categoryDTO.ToCategoryCast());
    //        _unitOfWork.Commit();

    //        return Ok(updatedCategory.ToCategoryDTOCast());
    //    }

    //    [HttpDelete("{id:int}")]
    //    public ActionResult Delete(int id)
    //    {
    //        Category category = _unitOfWork.CategoryRepository.GetById(id);

    //        if (category is null)
    //        {
    //            return BadRequest("Id inválido...");
    //        }

    //        _unitOfWork.CategoryRepository.Delete(category);
    //        _unitOfWork.Commit();

    //        return Ok("Categoria deletada!");
    //    }
    //    #endregion
    //}
    //#endregion

    //#region SeverityController
    //[ApiController]
    //[Route("[Controller]")]
    //public class SeverityController : ControllerBase
    //{
    //    #region Fields
    //    private readonly IUnitOfWork _unitOfWork;
    //    #endregion

    //    #region Constructor
    //    public SeverityController(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }
    //    #endregion

    //    #region Actions
    //    [HttpGet]
    //    public ActionResult<IEnumerable<SeverityDTO>> Get()
    //    {
    //        List<Severity> severities = _unitOfWork.SeverityRepository.GetAll().ToList();

    //        if (severities is null)
    //        {
    //            return NotFound("Nenhuma severidade foi encontrada...");
    //        }

    //        return Ok(severities.ToSeverityDTOListCast().ToList());
    //    }

    //    [HttpGet("{id:int}", Name = "GetNewSeverity")]
    //    public ActionResult<SeverityDTO> GetById(int id)
    //    {
    //        Severity severity = _unitOfWork.SeverityRepository.GetById(id);

    //        if (severity is null)
    //        {
    //            return BadRequest("Nenhuma severidade foi encontrada...");
    //        }

    //        return Ok(severity.ToSeverityDTOCast());
    //    }

    //    [HttpPost]
    //    public ActionResult<SeverityDTO> Post(SeverityDTO severityDTO)
    //    {
    //        if (severityDTO == null)
    //        {
    //            return BadRequest("Severidade não pode ser nula...");
    //        }

    //        Severity severity = _unitOfWork.SeverityRepository.Create(severityDTO.ToSeverityCast());
    //        _unitOfWork.Commit();

    //        SeverityDTO createdSeverity = severity.ToSeverityDTOCast();

    //        return new CreatedAtRouteResult("GetNewSeverity", new { id = createdSeverity.Id }, createdSeverity);
    //    }

    //    [HttpPut("{id:int}")]
    //    public ActionResult<SeverityDTO> Put(int id, SeverityDTO severityDTO)
    //    {
    //        if (id != severityDTO.Id)
    //        {
    //            return BadRequest("Id inválido..");
    //        }

    //        Severity updatedSeverity = _unitOfWork.SeverityRepository.Update(severityDTO.ToSeverityCast());
    //        _unitOfWork.Commit();

    //        return Ok(updatedSeverity.ToSeverityDTOCast());
    //    }

    //    [HttpDelete("{id:int}")]
    //    public ActionResult Delete(int id)
    //    {
    //        Severity severity = _unitOfWork.SeverityRepository.GetById(id);

    //        if (severity is null)
    //        {
    //            return BadRequest("Id inválido...");
    //        }

    //        _unitOfWork.SeverityRepository.Delete(severity);
    //        _unitOfWork.Commit();

    //        return Ok("Severidade deletada!");
    //    }
    //    #endregion
    //}
    //#endregion

    //#region ToDoController
    //[ApiController]
    //[Route("[Controller]")]
    //public class ToDoController : ControllerBase
    //{
    //    #region Fields
    //    private readonly IUnitOfWork _unitOfWork;
    //    #endregion

    //    #region Constructor
    //    public ToDoController(IUnitOfWork unitOfWork)
    //    {
    //        _unitOfWork = unitOfWork;
    //    }
    //    #endregion

    //    #region Actions
    //    [HttpGet]
    //    [ServiceFilter(typeof(LoggingFilter))]
    //    public ActionResult<IEnumerable<ToDoDTO>> Get()
    //    {
    //        List<ToDo> toDos = _unitOfWork.ToDoRepository.GetAll().ToList();

    //        if (toDos is null)
    //        {
    //            return BadRequest("Nenhum afazer encontrado...");
    //        }

    //        return Ok(toDos.ToToDoDTOListCast().ToList());
    //    }

    //    [HttpGet("{id:int}", Name = "GetNewToDo")]
    //    public ActionResult<ToDoDTO> GetById(int id)
    //    {
    //        ToDo toDo = _unitOfWork.ToDoRepository.GetById(id);

    //        if (toDo is null)
    //        {
    //            return BadRequest("Nenhum afazer encontrado...");
    //        }

    //        return Ok(toDo.ToToDoDTOCast());
    //    }

    //    [HttpGet("categoryId/{categoryId:int}")]
    //    public ActionResult<IEnumerable<ToDoDTO>> GetByCategory(int categoryId)
    //    {
    //        List<ToDo> toDos = _unitOfWork.ToDoRepository.GetAllByCategory(categoryId).ToList();

    //        if (toDos is null)
    //        {
    //            return BadRequest("Nenhum afazer encontrado..");
    //        }

    //        return Ok(toDos.ToToDoDTOListCast().ToList());
    //    }

    //    [HttpPost]
    //    public ActionResult<ToDoDTO> Post(ToDoDTO toDoDTO)
    //    {
    //        if (toDoDTO is null)
    //        {
    //            return BadRequest("Afazer não pode ser nulo...");
    //        }

    //        ToDo toDo = _unitOfWork.ToDoRepository.Create(toDoDTO.ToToDoCast());
    //        _unitOfWork.Commit();
    //        ToDoDTO createdtoDoDTO = toDo.ToToDoDTOCast();

    //        return new CreatedAtRouteResult("GetNewToDo", new { id = createdtoDoDTO.Id }, createdtoDoDTO);
    //    }

    //    [HttpPut("{id:int}")]
    //    public ActionResult<ToDoDTO> Put(int id, ToDoDTO toDoDTO)
    //    {
    //        if (id != toDoDTO.Id)
    //        {
    //            return BadRequest("Id inválido...");
    //        }

    //        ToDo updatedToDo = _unitOfWork.ToDoRepository.Update(toDoDTO.ToToDoCast());
    //        _unitOfWork.Commit();

    //        return Ok(updatedToDo.ToToDoDTOCast());
    //    }

    //    [HttpDelete("{id:int}")]
    //    public ActionResult Delete(int id)
    //    {
    //        ToDo toDo = _unitOfWork.ToDoRepository.GetById(id);

    //        if (toDo is null)
    //        {
    //            return BadRequest("Id inválido...");
    //        }

    //        _unitOfWork.ToDoRepository.Delete(toDo);
    //        _unitOfWork.Commit();

    //        return Ok("Afazer deletado...");
    //    }
    //    #endregion
    //}
    //#endregion
    #endregion
}
