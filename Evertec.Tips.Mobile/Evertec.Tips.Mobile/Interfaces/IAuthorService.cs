using System.Collections.Generic;
using System.Threading.Tasks;
using Evertec.Tips.Mobile.Domain.Models;

namespace Evertec.Tips.Mobile.Interfaces
{
    public interface IAuthorService
    {
        Task<bool> AddAuthor(AuthorModel item);

        Task<List<AuthorModel>> GetAll();
    }
}
