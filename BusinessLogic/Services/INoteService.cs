using Crud.DataAccess.Entities;

namespace Crud.BusinessLogic.Services;

public interface INoteService
{
    Task CreateAsync(string text, CancellationToken cancellationToken = default);
    Task<string> GetNoteByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(int id, string newText, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default);
}
