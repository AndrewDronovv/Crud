using Crud.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud.DataAccess.Repositories.Notes;

internal class NoteRepository : INoteRepository
{
    private readonly AppDbContext _context;

    public NoteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Note note, CancellationToken cancellationToken = default)
    {
        note.Created = DateTime.Now;
        await _context.Notes.AddAsync(note, cancellationToken);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Note note, CancellationToken cancellationToken = default)
    {
        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Notes.AsNoTracking().ToListAsync();
    }

    public async Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
    }

    public async Task UpdateAsync(Note note, CancellationToken cancellationToken = default)
    {
        note.Updated = DateTime.Now;
        _context.Notes.Update(note);
        await _context.SaveChangesAsync();
    }
}
