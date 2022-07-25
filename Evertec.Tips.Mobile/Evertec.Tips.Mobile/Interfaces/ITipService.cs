using Evertec.Tips.Mobile.Domain.Dtos;
using Evertec.Tips.Mobile.Domain.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.Interfaces
{
    public interface ITipService
    {
        Task<bool> DeleteTip(int id);

        Task<bool> UpdateTip(TipModel tip);

        Task<bool> AddTip(TipModel tip);

        Task<ObservableCollection<TipModel>> GetAll();

        Task<bool> UpdateTip(TipDto tip);

        Task<bool> AddTip(TipDto tip);
    }
}
