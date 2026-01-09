using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ToDo.BackEnd
{
    public abstract class CrudBaseController<TEntity, TEntityDTO> : ControllerBase
        where TEntity : class, IEntityBase
        where TEntityDTO : class, IEntityBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public CrudBaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        #endregion

        #region Actions
        [HttpGet]
        public ActionResult<IEnumerable<TEntityDTO>> Get()
        {
            List<TEntityDTO> entities = _mapper.Map<IEnumerable<TEntityDTO>>(_unitOfWork.Repository<TEntity>().GetAll()).ToList();

            if (entities is null)
            {
                return NotFound("Nenhum entidade foi encontrada.");
            }

            return Ok(entities);
        }

        [HttpGet("{id:int}")]
        public ActionResult<TEntityDTO> GetById(int id)
        {
            TEntityDTO entity = _mapper.Map<TEntityDTO>(_unitOfWork.Repository<TEntity>().GetById(id));

            if (entity is null)
                return NotFound($"Entidade não encontrada.");

            return Ok(entity);
        }

        [HttpPost]
        public ActionResult<TEntityDTO> Post(TEntityDTO entityDTO)
        {
            if (entityDTO is null)
            {
                return BadRequest("A entidade não pode ser nula.");
            }

            TEntity entity = _unitOfWork.Repository<TEntity>().Create(_mapper.Map<TEntity>(entityDTO));
            _unitOfWork.Commit();

            TEntityDTO newEntity = _mapper.Map<TEntityDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = newEntity.Id }, newEntity);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TEntityDTO> Put(int id, TEntityDTO entityDTO)
        {
            if (id != entityDTO.Id)
            {
                return BadRequest("Id inválido.");
            }

            TEntity updatedEntity = _unitOfWork.Repository<TEntity>().Update(_mapper.Map<TEntity>(entityDTO));
            _unitOfWork.Commit();

            return Ok(_mapper.Map<TEntityDTO>(updatedEntity));
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
