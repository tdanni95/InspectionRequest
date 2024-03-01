using InspectionRequestAPI.Infrastructure;
using InspectionRequestAPI.Infrastructure.Persistence;
using InspectionRequestAPI.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services
    .AddApplication()
    .AddAuth(builder.Configuration)
    .AddInfraStructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<InspectionRequestDbContext>();
    await SeedToolsAndExaminations.Seed(context);
    await SeedParticles.Seed(context);
}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger!.LogError(ex, "An error occurred during migration");
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
