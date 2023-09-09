using Microsoft.EntityFrameworkCore;
using Student_Management.Data;
using Student_Management.IRepository.Course;
using Student_Management.IRepository.Detail;
using Student_Management.IRepository.Student;
using Student_Management.IRepository.User;
using Student_Management.Repository.Course;
using Student_Management.Repository.Detail;
using Student_Management.Repository.Student;
using Student_Management.Repository.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IReadCourse, ReadCourse>();
builder.Services.AddScoped<IReadDetail, ReadDetail>();
builder.Services.AddScoped<IReadStudent, ReadStudent>();
builder.Services.AddScoped<IReadUser, ReadUser>();
builder.Services.AddScoped<IWriteCourse, WriteCourse>();
builder.Services.AddScoped<IWriteDetail, WriteDetail>();
builder.Services.AddScoped<IWriteStudent, WriteStudent>();
builder.Services.AddScoped<IWriteUser, WriteUser>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
