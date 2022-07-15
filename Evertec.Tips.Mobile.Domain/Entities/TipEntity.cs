using SQLite;
using System;

namespace Evertec.Tips.Mobile.Domain.Entities
{
    public class TipEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public DateTime CreationDate { get; set; }        

        [NotNull]
        public string Title { get; set; }

        public string Description { get; set; }

        [NotNull]
        public DateTime UpdateDate { get; set; }

        public int AuthorId { get; set; }
    }
}
