using Evertec.Tips.Mobile.Domain.Entities;
using SQLite;
using System;
using System.IO;

namespace Evertec.Tips.Mobile.Infrastructure.Providers
{
    public class DatabaseContextProvider : IDatabaseContextProvider
    {
        public SQLiteConnection _connection { get; }

        public DatabaseContextProvider()
        {
            _connection = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Tips.db3"));
            _connection.CreateTable<TipEntity>();
            _connection.CreateTable<AuthorEntity>();
        }

    }
}
