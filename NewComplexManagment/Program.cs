using Microsoft.EntityFrameworkCore;
using NewComplexManagment.EFPresistence;
using NewComplexManagment.EFPresistence.Repositories.Blocks;
using NewComplexManagment.EFPresistence.Repositories.Complexes;
using NewComplexManagment.EFPresistence.Repositories.ComplexUsageTypes;
using NewComplexManagment.EFPresistence.Repositories.Units;
using NewComplexManagment.EFPresistence.Repositories.UsageTypes;
using NewComplexManagment.Services.Blocks;
using NewComplexManagment.Services.Blocks.Contracts;
using NewComplexManagment.Services.Complexes;
using NewComplexManagment.Services.Complexes.Contracts;
using NewComplexManagment.Services.ComplexUsageType;
using NewComplexManagment.Services.ComplexUsageType.Contracts;
using NewComplexManagment.Services.Contracts;
using NewComplexManagment.Services.Units;
using NewComplexManagment.Services.Units.Contracts;
using NewComplexManagment.Services.UsageType;
using NewComplexManagment.Services.UsageType.Contracts;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ComplexService,ComplexAppService>();
builder.Services.AddScoped<ComplexRepository,EFComplexRepository>();
builder.Services.AddScoped<UnitOfWork ,EFUnitOfWork>();
builder.Services.AddScoped<BlockService,BlockAppService>();
builder.Services.AddScoped<BlockRepository,EFBlockRepository>();
builder.Services.AddScoped<UnitService,UnitAppService>();
builder.Services.AddScoped<UnitRepository,EFUnitRepository>();
builder.Services.AddScoped<UsageTypeService,UsageTypeAppService>();
builder.Services.AddScoped<UsageTypesRepository,EFUsageTypeRepository>();
builder.Services.AddScoped<ComplexUsageTypeService, ComplexUsageTypeAppService>();
builder.Services.AddScoped<ComplexUsageTypeRepository,EFComplexUsageTypeRepository>();
builder.Services.AddDbContext<EFDataContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("SqlServer"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
