using AutoMapper;

namespace ToDo.BackEnd
{
    public class EntityDTOMappingProfile : Profile
    {
        public EntityDTOMappingProfile()
        {
            CreateMap<ToDo, ToDoDTO>().ReverseMap();
        }
    }
}
