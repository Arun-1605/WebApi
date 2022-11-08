using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Model.DBContext;
using NZwalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NZDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Myconnection"));

});
builder.Services.AddMvc();

builder.Services.AddScoped<IRegionRepository, RegionRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();



app.Run();
