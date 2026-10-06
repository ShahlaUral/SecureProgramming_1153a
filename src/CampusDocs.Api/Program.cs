using CampusDocs.Api.Validations;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
 

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<StudentValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
