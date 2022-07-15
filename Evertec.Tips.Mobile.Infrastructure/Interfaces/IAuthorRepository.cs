using System.Collections.Generic;
using Evertec.Tips.Mobile.Domain.Entities;
using System.Threading.Tasks;
using Evertec.Tips.Mobile.Domain.Models;

namespace Evertec.Tips.Mobile.Infrastructure.Interfaces
{
    public interface IAuthorRepository
    {
        Task<bool> AddAuthor(AuthorEntity item);

        Task<List<AuthorEntity>> GetAll();
    }
}
