using Microsoft.EntityFrameworkCore;
using RaizenUserRegister.Application.Extension;
using RaizenUserRegister.Infra.Data.DBContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();
builder.Services.AddRepository();
builder.Services.AddHttpClientFactory();

builder.Services.AddDbContext<RaizenDBContext>(options =>
{
    var cnn = builder.Configuration.GetConnectionString("RaizenDB");

    options.UseSqlServer(cnn);
});

var app = builder.Build();

app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
