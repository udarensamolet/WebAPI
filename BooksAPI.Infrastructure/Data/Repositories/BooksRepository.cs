using BooksAPI.Infrastructure.Data.Common;
using BooksAPI.Infrastructure.Data.Contexts;

namespace BooksAPI.Infrastructure.Data.Repositories
{
    public class BooksRepository : Repository, IBooksRepository
    {
        public BooksRepository(BooksContext context)
            : base(context)
        {
        }
    }
}
