using Notes.DBModels;
using System.Collections.Generic;

namespace Notes.Repositories
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetAll(string userId);
        void Create(Note note);
        Note Get(int id, string userId);
        void Delete(Note note);
        void Update(Note note);
    }
}
