using ContactsApiProject.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// I added these lines for InMemoryDatabase
//builder.Services.AddDbContext<ContactsDbContext>(options =>
//         options.UseInMemoryDatabase("ContactsDetails"));

//added to connect with Sql Server
builder.Services.AddDbContext<ContactsDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsApiConnectionString")));


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