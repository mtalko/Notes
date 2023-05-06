using Notes.Data;
using Notes.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notes.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Note> GetAll(string userId)
        {
            return _context.Notes.Where(n => n.UserId == userId).OrderByDescending(n => n.Id).Take(5).ToList();
        }

        public void Create(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public Note Get(int id, string userId)
        {
            return _context.Notes.FirstOrDefault(p => p.Id == id && p.UserId == userId);
        }
        public void Delete(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
        public void Update(Note note)
        {
            _context.SaveChanges();
        }
    }
}
