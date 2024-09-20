using Microsoft.EntityFrameworkCore;
using Vendor_Management_System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(Vendor_Management_System.Vendor));
builder.Services.AddScoped(typeof(Vendor_Management_System.Invoice));
builder.Services.AddScoped(typeof(Vendor_Management_System.Currency));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .LogTo(log => File.AppendAllText("sandip.log", log + Environment.NewLine), LogLevel.Information);
});
builder.Services.AddCors(options =>

{

    options.AddPolicy("AllowAll",

        builder =>

        {

            builder.AllowAnyOrigin()

                   .AllowAnyMethod()

                   .AllowAnyHeader();

        });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
