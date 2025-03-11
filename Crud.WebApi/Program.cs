using Crud.BusinessLogic;
using Crud.DataAccess.Extensions;
using Crud.WebApi.MinimalEndpointExtension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusinessLogic();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();


app.MapNoteEndpoinds();


Console.WriteLine("going to start");

app.Run();