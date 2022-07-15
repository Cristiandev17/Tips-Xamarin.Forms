using Evertec.Tips.Mobile.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.Infrastructure.Interfaces
{
    public interface ITipRepository
    {
        Task<bool> DeleteTip(int id);

        Task<bool> UpdateTip(TipEntity item);

        Task<bool> AddTip(TipEntity item);

        Task<List<TipEntity>> GetAll();
    }
}
