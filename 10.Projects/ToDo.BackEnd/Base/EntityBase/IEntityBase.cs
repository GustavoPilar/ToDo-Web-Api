namespace ToDo.BackEnd
{
    public interface IEntityBase
    {
        int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
