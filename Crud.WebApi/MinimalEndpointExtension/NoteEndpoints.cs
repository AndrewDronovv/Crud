using Crud.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud.WebApi.MinimalEndpointExtension;

public static class NoteEndpoints
{
    public static void MapNoteEndpoinds(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("Note/minimal/");

        group.MapPost("", CreateAsync);
        group.MapDelete("{id:int}", DeleteNoteAsync);
        group.MapGet("{id:int}", GetNoteAsync);
        app.MapGet("Notes/minimal", GetNotesAsync);
        group.MapPut("{id:int}", UpdateNoteAsync);
    }
    private static async Task<IResult> CreateAsync(string text, INoteService noteService)
    {
        await noteService.CreateAsync(text);
        return Results.NoContent();
    }
    private static async Task<IResult> GetNoteAsync(int id, INoteService noteService)
    {
        var note = await noteService.GetNoteByIdAsync(id);
        return Results.Ok(note);
    }

    private static async Task<IResult> GetNotesAsync(INoteService noteService)
    {
        var notes = await noteService.GetAllAsync();
        return Results.Ok(notes);
    }

    private static async Task<IResult> UpdateNoteAsync([FromRoute] int id, string newText, INoteService noteService)
    {
        await noteService.UpdateAsync(id, newText);
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteNoteAsync(int id, INoteService noteService)
    {
        await noteService.DeleteAsync(id);
        return Results.NoContent();
    }
}
