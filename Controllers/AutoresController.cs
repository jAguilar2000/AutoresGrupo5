using AutoresGrupo5.Models;
using SQLite;

namespace AutoresGrupo5.Controllers
{
    public class AutoresController
    {
        readonly SQLiteAsyncConnection _connection;

        public AutoresController()
        {
            SQLiteOpenFlags extensiones = SQLiteOpenFlags.ReadWrite |
              //SQLiteOpenFlags.ReadOnly |
              SQLiteOpenFlags.Create |
              SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBAuthor.db3"), extensiones);
            _connection.CreateTableAsync<Autor>();
        }

        //Create //Update
        public async Task<int> StoreAutor(Autor autor)
        {
            if (autor.Id == 0)
            {
                return await _connection.InsertAsync(autor);
            }
            else
            {
                return await _connection.UpdateAsync(autor);
            }
        }

        //Read
        public async Task<List<Autor>> GetListAutor()
        {
            return await _connection.Table<Autor>().ToListAsync();
        }

        public async Task<List<Autor>> GetListAutorBuscar(string searchText)
        {
            return await _connection.Table<Autor>().Where(a => a.Nombres.ToLower().Contains(searchText) || a.Pais.ToLower().Contains(searchText)).ToListAsync();
        }

        public async Task<Autor> GetAutor(int id)
        {
            return await _connection.Table<Autor>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        //Delete
        public async Task<int> DeletePerson(Autor autor)
        {
            return await _connection.DeleteAsync(autor);
        }
    }
}
