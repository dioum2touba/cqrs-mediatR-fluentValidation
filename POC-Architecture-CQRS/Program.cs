using POC_Architecture_CQRS.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Configuration
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Inject services
builder.Services.AddDIConfiguration();

// Add Fluent Validation
builder.Services.AddAddFluentValidationConfiguration();

// Add Smart Search
builder.Services.AddSmartSearchConfiguration(builder.Configuration);

// Add MediatR Configuration
builder.Services.AddMediatR(Cfg => Cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

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