using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Evertec.Tips.Mobile.Domain.Entities;
using Evertec.Tips.Mobile.Domain.Models;

namespace Evertec.Tips.Mobile.Domain.Mappers
{
    public class TipMapper
    {
        public static Task<TipEntity> MapTipEntity(TipModel item)
        {
            return Task.FromResult(new TipEntity
            {
                Title = item.Title,
                Description = item.Description,
                Id = item.Id,
                CreationDate = item.CreationDate,
                UpdateDate = item.UpdateDate,
                AuthorId = item.AuthorId
            });
        }

        public static Task<ObservableCollection<TipModel>> MapTipsModel(List<TipEntity> items)
        {
            var itemsModel = new ObservableCollection<TipModel>();
            if (items != null && items.Any())
            {
                foreach (var item in items)
                {
                    itemsModel.Add(new TipModel
                    {
                        Title = item.Title,
                        Description = item.Description,
                        Id = item.Id,
                        CreationDate = item.CreationDate,
                        UpdateDate = item.UpdateDate,
                        AuthorId = item.AuthorId
                    });
                }
            }

            return Task.FromResult(itemsModel);
        }
    }
}
