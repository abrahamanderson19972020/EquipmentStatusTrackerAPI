using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
        .WriteTo.Console()
        .WriteTo.Debug());

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register Data Access Layer Services
builder.Services.AddScoped<IAddressDal, EfAddressDal>();
builder.Services.AddScoped<ICommunicationDetailDal, EfCommunicationDetailDal>();
builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
builder.Services.AddScoped<IEquipmentDal, EfEquipmentDal>();
builder.Services.AddScoped<IEquipmentShippingDetailDal, EfEquipmentShippingDetailDal>();
builder.Services.AddScoped<IEquipmentStatusDal, EfEquipmentStatusDal>();
builder.Services.AddScoped<IGpsPositionDal, EfGpsPositionDal>();

// Register Business Layer Services
builder.Services.AddScoped<IAddressService, AddressManager>();
builder.Services.AddScoped<ICommunicationDetailService, CommunicationDetailManager>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IEquipmentService, EquipmentManager>();
builder.Services.AddScoped<IEquipmentShippingDetailService, EquipmentShippingDetailManager>();
builder.Services.AddScoped<IEquipmentStatusService, EquipmentStatusManager>();
builder.Services.AddScoped<IGpsPositionService, GpsPositionManager>();

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.ReportApiVersions = true;
    setupAction.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
}).AddMvc();

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
