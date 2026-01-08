using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ToDo.BackEnd
{
    public abstract class CrudBaseController<TEntity, TEntityDto> : ControllerBase
        where TEntity : class
        where TEntityDto : class
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CrudBaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Cast() 
        [NonAction]
        public TEntity? CastToTEntity(TEntityDto dto)
        {
            return dto.GetType().GetMethod("ToCastEntity").Invoke(dto, null) as TEntity;
        }
        [NonAction]
        public TEntityDto? CastToEntityDTO(TEntity entity)
        {
            return entity.GetType().GetMethod("ToCastDTO").Invoke(entity, null) as TEntityDto;
        }
        [NonAction]
        public IEnumerable<TEntityDto>? CastToIEnumerable(IEnumerable<TEntity> entities)
        {
            return entities.Select(x => x.GetType().GetMethod("ToCastDTO").Invoke(x, null) as TEntityDto);
        }
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<TEntityDto>> Get()
        {
            List<TEntityDto> entities = CastToIEnumerable(_unitOfWork.Repository<TEntity>().GetAll()).ToList();

            if (entities is null)
            {
                return NotFound("Nenhum entidade foi encontrada.");
            }

            return Ok(entities);
        }

        [HttpGet("/{id:int}", Name = "GetNewEntity")]
        public ActionResult<TEntityDto> GetById(int id)
        {
            TEntityDto entity = CastToEntityDTO(_unitOfWork.Repository<TEntity>().GetById(id));

            if (entity is null)
                return NotFound($"Entidade não encontrada.");

            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<TEntityDto> Post(TEntityDto entityDto)
        {
            if (entityDto is null)
            {
                return BadRequest("A entidade não pode ser nula.");
            }

            TEntity entity = _unitOfWork.Repository<TEntity>().Create(CastToTEntity(entityDto));
            _unitOfWork.Commit();

            TEntityDto newEntity = CastToEntityDTO(entity);

            return new CreatedAtRouteResult("GetNewCategory", new { id = newEntity.GetType().GetProperty("Id") }, newEntity);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TEntityDto> Put(int id, TEntityDto entityDto)
        {
            if (id != (int)(entityDto.GetType().GetProperty("Id").GetValue(entityDto)))
            {
                return BadRequest("Id inválido.");
            }

            TEntity updatedEntity = _unitOfWork.Repository<TEntity>().Update(CastToTEntity(entityDto));
            _unitOfWork.Commit();

            return Ok(CastToEntityDTO(updatedEntity));
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            TEntity entity = _unitOfWork.Repository<TEntity>().GetById(id);

            if (entity is null)
            {
                return BadRequest("Id inválido.");
            }

            _unitOfWork.Repository<TEntity>().Delete(entity);
            _unitOfWork.Commit();

            return Ok("Entidade deletada!");
        }
        #endregion
    }
}
