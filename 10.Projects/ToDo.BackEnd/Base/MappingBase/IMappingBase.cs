namespace ToDo.BackEnd
{
    public static class MappingBase
    {
        #region Entities :: Category, Severity, ToDo

        #region Category
        public static Category ToCastEntity(this CategoryDTO categoryDTO)
        {
            return new Category()
            {
                Id = categoryDTO.Id,
                Code = categoryDTO.Code,
                Description = categoryDTO.Description
            };
        }

        public static CategoryDTO? ToCastDTO(this Category category)
        {
            return new CategoryDTO()
            {
                Id = category.Id,
                Code = category.Code,
                Description = category.Description
            };
        }
        #endregion

        #region Severity
        public static Severity? ToSeverityCast(this SeverityDTO severityDTO)
        {
            if (severityDTO is null)
            {
                 return null;
            }

            return new Severity()
            {
                Id = severityDTO.Id,
                Code = severityDTO.Code,
                Description = severityDTO.Description
            };
        }

        public static SeverityDTO? ToSeverityDTOCast(this Severity severity)
        {
            if (severity is null)
            {
                return null;
            }

            return new SeverityDTO()
            {
                Id = severity.Id,
                Code = severity.Code,
                Description = severity.Description
            };
        }

        public static IEnumerable<SeverityDTO> ToSeverityDTOListCast(this IEnumerable<Severity> severities)
        {
            if (severities is null || !severities.Any())
            {
                return new List<SeverityDTO>();
            }

            return severities.Select(severity => severity.ToSeverityDTOCast());
        }
        #endregion

        #region ToDo
        public static ToDoDTO? ToToDoDTOCast(this ToDo toDo)
        {
            if (toDo is null)
            {
                return null;
            }

            return new ToDoDTO()
            {
                Id = toDo.Id,
                Code = toDo.Code,
                Description = toDo.Description,
                AlreadyDone = toDo.AlreadyDone,
                StartDateTime = toDo.StartDateTime,
                FinishDateTime = toDo.FinishDateTime,
                CategoryId = toDo.CategoryId,
                SeverityId = toDo.SeverityId
            };
        }

        public static ToDo? ToToDoCast(this ToDoDTO toDoDTO)
        {
            if (toDoDTO is null)
            {
                return null;
            }

            return new ToDo()
            {
                Id = toDoDTO.Id,
                Code = toDoDTO.Code,
                Description = toDoDTO.Description,
                AlreadyDone = toDoDTO.AlreadyDone,
                StartDateTime = toDoDTO.StartDateTime,
                FinishDateTime = toDoDTO.FinishDateTime,
                CategoryId = toDoDTO.CategoryId,
                SeverityId = toDoDTO.SeverityId
            };
        }

        public static IEnumerable<ToDoDTO> ToToDoDTOListCast(this IEnumerable<ToDo> toDos)
        {
            if (toDos is null || !toDos.Any())
            {
                return new List<ToDoDTO>();
            }

            return toDos.Select(toDo => toDo.ToToDoDTOCast());
        }
        #endregion
        #endregion
    }
}
