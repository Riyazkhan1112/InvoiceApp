using InvoiceApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseNpgsql(
//        builder.Configuration.GetConnectionString("DefaultConnection"));
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNetlify", policy =>
    {
        policy.WithOrigins(
                "https://invoice44.netlify.app",
                "http://localhost:5500",
                "https://localhost:5001"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowNetlify");

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();