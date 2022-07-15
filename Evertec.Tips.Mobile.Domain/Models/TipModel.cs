using System;
using Evertec.Tips.Mobile.Domain.Entities;
using Evertec.Tips.Mobile.Domain.Enumerations;

namespace Evertec.Tips.Mobile.Domain.Models
{
    public class TipModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int AuthorId { get; set; }


        public Response Validate()
        {
            if (AuthorId == 0)
                return new Response(Validations.RequiredAuthor.ToString(), false);

            if (string.IsNullOrEmpty(Title))
                return new Response(Validations.RequiredTitle.ToString(), false);

            return new Response();
        }
    }
}
