using Books.Infrastructure.Data.Common;
using Books.Infrastructure.Data.Contexts;

namespace Books.Infrastructure.Data.Repositories
{
    public class BooksRepository : Repository, IBooksRepository
    {
        public BooksRepository(BooksContext context)
            : base(context)
        {
        }
    }
}
