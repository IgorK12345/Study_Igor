using Logic.Interfaces;
using Logic.Services;
using Microsoft.EntityFrameworkCore;
using Storage.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IHeadTeacherService, HeadTeacherService>();

builder.Services.AddControllers();

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
