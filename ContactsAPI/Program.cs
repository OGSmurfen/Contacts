using ContactsAPI.Data;
using ContactsAPI.Repository.IRepository;
using ContactsAPI.Repository.RepositoryImpl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//DB:
//builder.Services.AddScoped<ContactsDbContext>();
builder.Services.AddDbContext<ContactsDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ContactsDB")));


builder.Services.AddScoped<IContactsRepository, ContactsReposiotry>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
