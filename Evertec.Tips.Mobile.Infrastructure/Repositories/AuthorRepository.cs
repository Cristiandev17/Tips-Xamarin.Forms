using System.Collections.Generic;
using System.Threading.Tasks;
using Evertec.Tips.Mobile.Domain.Entities;
using Evertec.Tips.Mobile.Infrastructure.Interfaces;
using Evertec.Tips.Mobile.Infrastructure.Providers;

namespace Evertec.Tips.Mobile.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private IDatabaseContextProvider _contextProvider;

        public AuthorRepository(IDatabaseContextProvider contextProvider)
        {
            this._contextProvider = contextProvider;
        }

        public Task<bool> AddAuthor(AuthorEntity item)
        {
            var result = new bool();
            var response = _contextProvider._connection.Insert(item);
            if (response != 0)
                result = true;

            return Task.FromResult(result);
        }

        public Task<List<AuthorEntity>> GetAll()
        {
            var authors = _contextProvider._connection.Table<AuthorEntity>().ToList();
            return Task.FromResult(authors);

        }
    }
}
