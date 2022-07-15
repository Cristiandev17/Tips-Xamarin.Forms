using SQLite;

namespace Evertec.Tips.Mobile.Infrastructure.Providers
{
    public interface IDatabaseContextProvider
    {
        SQLiteConnection _connection { get; }
    }
}
