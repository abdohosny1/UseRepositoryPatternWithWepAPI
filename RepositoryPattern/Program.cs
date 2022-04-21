using Microsoft.EntityFrameworkCore;
using RepoistoryPatternWith.Core;
using RepoistoryPatternWith.Core.Repository;
using RepoistoryPatternWith.EF;
using RepoistoryPatternWith.EF.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add repository
//builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
//unit of work
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

//add dbcontext

 var connection = builder.Configuration.GetConnectionString("DefultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(
    op => op.UseSqlServer(connection,
           b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
