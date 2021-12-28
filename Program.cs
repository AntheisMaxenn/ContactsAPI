using AutoMapper;
using ContactsAPI.Data;
using ContactsAPI.Mapping;
using ContactsAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

//readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContactsContext>(options => options.UseSqlServer(
            builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddAutoMapper(typeof(RequestToDomainProfile));

// Registering the ContactService service
//builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddTransient<IContactService, ContactService>();

builder.Services.AddCors(options =>
    {   options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
    });
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
