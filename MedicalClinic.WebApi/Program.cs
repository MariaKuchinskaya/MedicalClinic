using AutoMapper;
using EfWebTutorial.Repositories;
using MedicalClinic.BusinessLayer.Configurations;
using MedicalClinic.BusinessLayer.Services;
using MedicalClinic.DAL;
using MedicalClinic.DAL.Repositories;
using MedicalClinic.DAL.Repositories.Interfaces;
using MedicalClinic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PatientRepository, PatientRepository>();
builder.Services.AddScoped<DoctorRepository, DoctorRepository>();
builder.Services.AddScoped<UserRepository, UserRepository>();
builder.Services.AddScoped<AppointmentRepository, AppointmentRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

var config = new MapperConfiguration(c =>
{
    c.AddProfile<BusinessLayerProfile>();
});

config.CompileMappings();
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();





