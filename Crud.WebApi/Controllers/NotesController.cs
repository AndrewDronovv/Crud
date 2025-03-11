using Crud.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud.WebApi.Controllers;

[Route("Note")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(string text)
    {
        await _noteService.CreateAsync(text);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNoteAsync([FromRoute] int id)
    {
        var note = await _noteService.GetNoteByIdAsync(id);
        return Ok(note);
    }

    [HttpGet("/Notes")]
    public async Task<IActionResult> GetNotesAsync()
    {
        var notes = await _noteService.GetAllAsync();
        return Ok(notes);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNoteAsync([FromRoute] int id, [FromBody] string newText)
    {
        await _noteService.UpdateAsync(id, newText);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNoteAsync([FromRoute] int id)
    {
        await _noteService.DeleteAsync(id);
        return NoContent();
    }
}
