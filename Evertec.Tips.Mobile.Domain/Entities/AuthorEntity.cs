using SQLite;

namespace Evertec.Tips.Mobile.Domain.Entities
{
    public class AuthorEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string AuthorName { get; set; }
    }
}
