using EsameIfoa_Server.Domain.Models;
using EsameIfoa_Server.Domain.Repositories;
using EsameIfoa_Server.Domain.Services;
using EsameIfoa_Server.Infrastructure.Data;
using EsameIfoa_Server.Infrastructure.Repositories;
using EsameIfoa_Server.Infrastructure.Services;
using EsameIfoa_Server.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(typeof(ContactProfile));


builder.Services.AddCors(options =>

{

  options.AddPolicy("AllowAllOrigins",

      builder =>

      {

        builder.AllowAnyOrigin()

                 .AllowAnyMethod()

                 .AllowAnyHeader();

      });

});

builder.Services.AddDbContext<DataContext>(options =>

    options.UseSqlServer("Server=localhost;Database=EsameIfoa;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();
app.UseCors("AllowAllOrigins");

app.MapControllers();
using (IServiceScope scope = app.Services.CreateScope())

{

  DataContext context = scope.ServiceProvider.GetRequiredService<DataContext>();

  context.Database.EnsureDeleted();

  context.Database.EnsureCreated();

  if (!context.Contact.Any())

  {

    context.Contact.AddRange(

        new Contact

        {

          FullName = "Ilenia Taccogna",

          Email = "Taccogna@gmail.com",
          Phone= "3388456789",
          Department="DevOps"

        },

        new Contact

        {

          FullName = "Filippo Addabbo",

          Email = "Taccogna@gmail.com",
          Phone = "3388456789",
          Department = "DevOps"

        },

         new Contact

         {
           FullName = "Davide Colucci",

           Email = "Taccogna@gmail.com",
           Phone = "3388456789",
           Department = "DevOps"
         }

          );

    context.SaveChanges();

  }
}

  app.Run();
