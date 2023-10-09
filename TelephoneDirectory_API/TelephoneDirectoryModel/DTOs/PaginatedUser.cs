using TelephoneDirectoryModel.Entity;

namespace TelephoneDirectoryModel.ModelView
{

    public class PaginatedUser
    {
        public int TotalUsers { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<User> Users { get; set; }

    }

}
