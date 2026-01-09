using EfCoreLab;
using EfCoreLab.Data;
using EfCoreLab.Repositories;

var builder = WebApplication.CreateBuilder(args);

// TODO: Students should add EF Core configuration here
// Step 1: Add DbContext service with UseSqlServer
// Example:
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<ITelephoneNumberRepository, TelephoneNumberRepository>();

// Configure seed settings
builder.Services.Configure<SeedSettings>(builder.Configuration.GetSection("SeedSettings"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// TODO: Students should implement database initialization
// After implementing DbContext and migrations:
// 1. Uncomment the code below
// 2. Run migrations to create the database
// 3. Seed data will be automatically generated

/*
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        var seedSettings = builder.Configuration.GetSection("SeedSettings").Get<SeedSettings>() ?? new SeedSettings();
        
        logger.LogInformation("Checking database...");
        
        // Ensure database is created
        await context.Database.EnsureCreatedAsync();
        
        // Seed data if enabled and database is empty
        if (seedSettings.EnableSeeding)
        {
            logger.LogInformation("Seeding is enabled. Checking for existing data...");
            await BogusDataGenerator.SeedDatabase(
                context,
                customerCount: seedSettings.CustomerCount,
                minInvoicesPerCustomer: seedSettings.MinInvoicesPerCustomer,
                maxInvoicesPerCustomer: seedSettings.MaxInvoicesPerCustomer,
                minPhoneNumbersPerCustomer: seedSettings.MinPhoneNumbersPerCustomer,
                maxPhoneNumbersPerCustomer: seedSettings.MaxPhoneNumbersPerCustomer
            );
        }
        else
        {
            logger.LogInformation("Database seeding is disabled in configuration.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
*/

// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EF Core Lab API V1");
    c.RoutePrefix = string.Empty;
});

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
