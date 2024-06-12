using AutoresGrupo5.Models;
using SQLite;

namespace AutoresGrupo5.Controllers
{

    public class PaisesController
    {
        readonly SQLiteAsyncConnection _connection;

        public PaisesController()
        {
            SQLiteOpenFlags extensiones = SQLiteOpenFlags.ReadWrite |
              //SQLiteOpenFlags.ReadOnly |
              SQLiteOpenFlags.Create |
              SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBAuthor.db3"), extensiones);
            _connection.CreateTableAsync<Paises>();
        }

        public async Task<int> StorePais(Paises pais)
        {
            if (pais.Id == 0)
            {
                return await _connection.InsertAsync(pais);
            }
            else
            {
                return await _connection.UpdateAsync(pais);
            }
        }
        public async Task<List<Paises>> GetListPaises()
        {
            return await _connection.Table<Paises>().ToListAsync();
        }
    }
}
