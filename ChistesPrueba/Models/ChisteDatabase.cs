using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChistesPrueba.Models
{
    public class ChisteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ChisteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Chiste>().Wait();
        }

        public Task<List<Chiste>> GetChistesAsync()
        {
            return _database.Table<Chiste>().ToListAsync();
        }

        public Task<Chiste> GetChisteAsync(int id)
        {
            return _database.Table<Chiste>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveChisteAsync(Chiste chiste)
        {
            if (chiste.ID != 0)
            {
                return _database.UpdateAsync(chiste);
            }
            else
            {
                return _database.InsertAsync(chiste);
            }
        }

        public Task<int> DeleteChisteAsync(Chiste chiste)
        {
            return _database.DeleteAsync(chiste);
        }
    }
}
