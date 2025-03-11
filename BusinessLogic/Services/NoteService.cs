using Crud.DataAccess.Entities;

namespace Crud.BusinessLogic.Services;

internal class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task CreateAsync(string text, CancellationToken cancellationToken = default)
    {
        var note = new Note
        {
            Text = text
        };

        await _noteRepository.CreateAsync(note, cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var note = await _noteRepository.GetByIdAsync(id, cancellationToken);
        if (note is null)
            throw new Exception("Note wasn't found");

        await _noteRepository.DeleteAsync(note, cancellationToken);
    }

    public async Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var notes = await _noteRepository.GetAllAsync(cancellationToken);
        if (notes is null)
            throw new Exception("Note wasn't found");

        return notes;
    }

    public async Task<string> GetNoteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var note = await _noteRepository.GetByIdAsync(id, cancellationToken);
        if (note is null)
            throw new Exception("Note wasn't found");

        return note.Text;
    }

    public async Task UpdateAsync(int id, string newText, CancellationToken cancellationToken = default)
    {
        var note = await _noteRepository.GetByIdAsync(id, cancellationToken);
        if (note is null)
            throw new Exception("Note wasn't found");

        note.Text = newText;

        await _noteRepository.UpdateAsync(note, cancellationToken);
    }
}
