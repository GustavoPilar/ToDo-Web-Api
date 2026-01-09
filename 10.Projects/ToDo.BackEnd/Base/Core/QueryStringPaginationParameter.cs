namespace ToDo.BackEnd
{
    public class QueryStringPaginationParameter
    {
        const int maxSize = 500;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = maxSize;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxSize) ? maxSize : value;
            }
        }
    }
}
