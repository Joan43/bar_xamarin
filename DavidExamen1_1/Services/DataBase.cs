using DavidExamen1_1.Models;
using SQLite;

namespace DavidExamen1_1.Services
{
    public class DataBase
    {
        public static SQLiteAsyncConnection connection;

       /* public static readonly AsyncLazy<DataBase> Instance = new AsyncLazy<DataBase>(async () =>
        {
            var instance = new DataBase();
            CreateTableResult result = await Database.CreateTableAsync<Alumne>();
            return instance;
        });*/

        static DataBase()
        {
            connection = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            connection.CreateTableAsync<Alumne>();
            connection.CreateTableAsync<Provincia>();
            connection.CreateTableAsync<Poblacio>();
        }
    }
}
