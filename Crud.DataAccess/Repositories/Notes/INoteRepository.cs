﻿using Crud.DataAccess.Entities;

public interface INoteRepository
{
    Task CreateAsync(Note note, CancellationToken cancellationToken = default);
    Task<Note?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(Note note, CancellationToken cancellationToken = default);
    Task DeleteAsync(Note note, CancellationToken cancellationToken = default);
    Task<IEnumerable<Note>> GetAllAsync(CancellationToken cancellationToken = default);
}
