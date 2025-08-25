using System.Text.Json;

using MantraUML.Application.Interfaces;
using MantraUML.Application.Profiles;
using MantraUML.Application.Services;
using MantraUML.Domain.Interfaces;
using MantraUML.Infrastructure.Data;
using MantraUML.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
        opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    );
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(connectionString)
);

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IDiagramRepository, DiagramRepository>();
builder.Services.AddScoped<IDiagramService, DiagramService>();
builder.Services.AddScoped<IDiagramTypeRepository, DiagramTypeRepository>();
builder.Services.AddScoped<IDiagramTypeService, DiagramTypeService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile(typeof(AutoMapperProfile)));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = builder.Configuration["AuthService:Authority"];
        options.Audience = builder.Configuration["AuthService:Audience"];
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(cors =>
{
    cors.AllowAnyOrigin();
    cors.AllowAnyHeader();
    cors.AllowAnyMethod();
});

app.MapControllers();

app.Run();
