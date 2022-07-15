using Evertec.Tips.Mobile.Domain.Entities;
using Evertec.Tips.Mobile.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evertec.Tips.Mobile.Domain.Mappers
{
    public class AuthorMapper
    {
        public static Task<AuthorEntity> MapAuthorEntity(AuthorModel item)
        {
            return Task.FromResult(new AuthorEntity
            {
                AuthorName = item.Name,
            });
        }

        public static Task<List<AuthorModel>> MapAuthorsModel(List<AuthorEntity> items)
        {
            var itemsModel = new List<AuthorModel>();
            if (items != null && items.Any())
            {
                foreach (var item in items)
                {
                    itemsModel.Add(new AuthorModel
                    {
                        Id = item.Id,
                        Name = item.AuthorName
                    });
                }
            }

            return Task.FromResult(itemsModel);
        }
    }
}
