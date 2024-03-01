using InspectionRequestAPI.Infrastructure;

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

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
