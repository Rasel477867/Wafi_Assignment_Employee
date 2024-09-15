namespace EmployeesWeb.Models
{
    public class PaginationModel
    {
            public int CurrentPage { get; private set; }
            public int TotalPages { get; private set; }
            public int PageSize { get; private set; }
            public int TotalItems { get; private set; }
            public bool HasPreviousPage => CurrentPage > 1;
            public bool HasNextPage => CurrentPage < TotalPages;
            public bool IsFirstPage => CurrentPage == 1;
            public bool IsLastPage => CurrentPage == TotalPages;
        
            public PaginationModel(int count, int pageNumber, int pageSize)
            {
                TotalItems = count;
                PageSize = pageSize;
                CurrentPage = pageNumber;
                TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            }


    }
}
