using FeedbackSystem13519.Data;
using FeedbackSystem13519.Repositories;
using Microsoft.EntityFrameworkCore;
using FeedbackSystem13519.Models;
using Microsoft.Build.Execution;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FeedbackDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));
builder.Services.AddScoped<IRepository<Feedback>, FeedbackRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:4200") 
        .AllowAnyMethod()
        .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowOrigin");


app.UseAuthorization();

app.MapControllers();

app.Run();
