using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class Database
{
    private readonly SQLiteAsyncConnection _database;

    public Database(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Note>().Wait();
    }

    public Task<List<Note>> GetNotesAsync() => _database.Table<Note>().ToListAsync();
    public Task<int> SaveNoteAsync(Note note) => _database.InsertAsync(note);
    public Task<int> DeleteNoteAsync(Note note) => _database.DeleteAsync(note);
}