using HealthPlus.Application.Interfaces.Repositories;
using HealthPlus.Application.Interfaces.Services;
using HealthPlus.Application.Services;
using HealthPlus.Infrastructure.Perisstence.Repositories;
using HealthPlus.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(a => a.AddPolicy("HealthPlus", b =>
{
    b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
var connectionString = builder.Configuration.GetConnectionString("ConnectionContext");
builder.Services.AddDbContext<HealthPlusContext>(x => x.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddScoped<IRepository, BaseRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IHospitalServiceService, HospitalServiceService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IConsultationService, ConsultationService> ();
builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<INurseService, NurseService>();
builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true

    };
});

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("HealthPlus");
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
