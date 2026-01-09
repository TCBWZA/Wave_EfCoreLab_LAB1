# Entity Framework Core - Code First Lab

## Lab Objectives

This lab teaches you how to implement Entity Framework Core using a **Code First** approach. You'll learn:

1. Setting up EF Core with SQL Server
2. Creating a DbContext
3. Configuring entities with Fluent API
4. Creating and running migrations
5. Implementing the Repository pattern with EF Core
6. Advanced querying techniques (Include, AsNoTracking, AsSplitQuery, pagination)

## Prerequisites

- .NET 8 SDK installed
- SQL Server (LocalDB, Express, or full version)
- Visual Studio 2022+ or VS Code with C# extension
- Basic knowledge of C# and async/await

## Getting Started

### Step 1: Install EF Core NuGet Packages

Open the **Package Manager Console** in Visual Studio:
- **Tools** > **NuGet Package Manager** > **Package Manager Console**

Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 8.0.0
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 8.0.0
Install-Package Microsoft.EntityFrameworkCore.Design -Version 8.0.0
```

**OR** uncomment the package references in `EfCoreLab_LAB1.csproj` and restore packages.

### Step 2: Update Connection String

Open `appsettings.json` and update the connection string for your SQL Server instance:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=efCoreLabs;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

**For LocalDB**, use:
```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=efCoreLabs;Trusted_Connection=True;MultipleActiveResultSets=true"
```

### Step 3: Implement the DbContext

Open `Data/AppDbContext.cs` and implement the following:

#### 3.1 Inherit from DbContext

```csharp
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
```

#### 3.2 Add DbSet Properties

```csharp
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<TelephoneNumber> TelephoneNumbers { get; set; } = null!;
```

#### 3.3 Override OnModelCreating

Configure entities using Fluent API. See the TODO comments in the file for detailed configuration requirements.

**Key concepts to implement:**
- Primary keys and auto-generation
- String max lengths
- Decimal precision
- Foreign key relationships
- Unique indexes
- Check constraints
- Ignored properties (computed properties like Balance)

### Step 4: Configure Services in Program.cs

Uncomment and add the DbContext configuration:

```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### Step 5: Create and Run Migrations

#### 5.1 Add Initial Migration

Open **Package Manager Console** and run:

```powershell
Add-Migration InitialCreate
```

This creates a migration file in the `Migrations` folder with:
- `Up()` method: Creates the database schema
- `Down()` method: Reverts the migration

**Examine the generated migration** to understand what EF Core will do to your database.

#### 5.2 Update the Database

```powershell
Update-Database
```

This executes the migration and creates the database with all tables.

#### 5.3 Verify Database Creation

Connect to your SQL Server and verify:
- Database `efCoreLabs` exists
- Tables: `Customers`, `Invoices`, `TelephoneNumbers`, `__EFMigrationsHistory`
- Constraints and indexes are created

### Step 6: Implement Repositories

Now implement the repository methods in:
- `Repositories/CustomerRepository.cs`
- `Repositories/InvoiceRepository.cs`
- `Repositories/TelephoneNumberRepository.cs`

#### 6.1 Basic CRUD Operations

**GetByIdAsync** - Retrieve a single entity by ID
```csharp
public async Task<Customer?> GetByIdAsync(long id, bool includeRelated = false)
{
    var query = _context.Customers.AsQueryable();
    
    if (includeRelated)
    {
        query = query
            .Include(c => c.Invoices)
            .Include(c => c.PhoneNumbers);
    }
    
    return await query.FirstOrDefaultAsync(c => c.Id == id);
}
```

**CreateAsync** - Add a new entity
```csharp
public async Task<Customer> CreateAsync(Customer customer)
{
    _context.Customers.Add(customer);
    await _context.SaveChangesAsync();
    return customer;
}
```

**UpdateAsync** - Update an existing entity
```csharp
public async Task<Customer> UpdateAsync(Customer customer)
{
    _context.Customers.Update(customer);
    await _context.SaveChangesAsync();
    return customer;
}
```

**DeleteAsync** - Remove an entity
```csharp
public async Task<bool> DeleteAsync(long id)
{
    var customer = await _context.Customers.FindAsync(id);
    if (customer == null) return false;
    
    _context.Customers.Remove(customer);
    await _context.SaveChangesAsync();
    return true;
}
```

#### 6.2 Advanced Querying Techniques

**Eager Loading with Include**
```csharp
var customer = await _context.Customers
    .Include(c => c.Invoices)
    .Include(c => c.PhoneNumbers)
    .FirstOrDefaultAsync(c => c.Id == id);
```

**AsNoTracking for Read-Only Queries** (10-30% faster)
```csharp
var customers = await _context.Customers
    .AsNoTracking()
    .Include(c => c.Invoices)
    .ToListAsync();
```

**AsSplitQuery to Avoid Cartesian Explosion**
```csharp
var customers = await _context.Customers
    .AsSplitQuery()  // Executes separate queries for each collection
    .Include(c => c.Invoices)
    .Include(c => c.PhoneNumbers)
    .ToListAsync();
```

**Pagination with Skip/Take**
```csharp
var totalCount = await query.CountAsync();
var items = await query
    .OrderBy(c => c.Name)  // Always order before pagination!
    .Skip((page - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync();
```

**Dynamic Filtering**
```csharp
var query = _context.Customers.AsQueryable();

if (!string.IsNullOrEmpty(name))
    query = query.Where(c => c.Name.Contains(name));

if (!string.IsNullOrEmpty(email))
    query = query.Where(c => c.Email.Contains(email));

var results = await query.ToListAsync();
```

### Step 7: Enable Database Seeding

Once your repositories are implemented, uncomment the seeding code in `Program.cs`.

The project uses **Bogus** library to generate realistic fake data automatically.

### Step 8: Run and Test

1. **Build the solution** (**Ctrl+Shift+B**)
2. **Run the application** (**F5**)
3. **Swagger UI** opens automatically at the root URL
4. Test all endpoints:
   - GET /api/customers
   - GET /api/customers/{id}
   - POST /api/customers
   - PUT /api/customers/{id}
   - DELETE /api/customers/{id}

## Learning Checkpoints

### Checkpoint 1: Basic Setup
- [ ] EF Core packages installed
- [ ] DbContext implemented with DbSet properties
- [ ] Connection string configured
- [ ] Initial migration created and applied
- [ ] Database created in SQL Server

### Checkpoint 2: Entity Configuration
- [ ] Primary keys configured
- [ ] String lengths set
- [ ] Foreign keys established
- [ ] Unique indexes created
- [ ] Check constraints added
- [ ] Computed properties ignored

### Checkpoint 3: Basic CRUD
- [ ] Create operation working
- [ ] Read single entity working
- [ ] Read all entities working
- [ ] Update operation working
- [ ] Delete operation working

### Checkpoint 4: Advanced Queries
- [ ] Eager loading with Include
- [ ] AsNoTracking for performance
- [ ] AsSplitQuery to avoid cartesian explosion
- [ ] Pagination implemented
- [ ] Dynamic filtering working

### Checkpoint 5: Testing
- [ ] All API endpoints respond correctly
- [ ] Data seeding populates database
- [ ] Swagger UI documentation works
- [ ] Validation rules enforced

## Useful EF Core CLI Commands

```powershell
# Add a new migration
Add-Migration <MigrationName>

# Update database to latest migration
Update-Database

# Rollback to specific migration
Update-Database <MigrationName>

# Remove last migration (if not applied)
Remove-Migration

# Generate SQL script from migrations
Script-Migration

# List all migrations
Get-Migration

# Drop database (careful!)
Drop-Database
```

## Additional Learning Resources

### EF Core Patterns Demonstrated

1. **Repository Pattern**: Abstraction layer between data access and business logic
2. **Dependency Injection**: Services injected via constructor
3. **Async/Await**: Non-blocking database operations
4. **DTO Pattern**: Separate models for API responses
5. **Unit of Work**: Implicit through DbContext and SaveChanges

### Performance Tips

- Use `AsNoTracking()` for read-only queries
- Use `AsSplitQuery()` when loading multiple collections
- Always `OrderBy()` before `Skip()`/`Take()`
- Use `CountAsync()` separately from data queries for pagination
- Avoid `ToList()` in where clauses (causes client evaluation)
- Use projection (`Select`) to load only needed columns

### Common Pitfalls

**Don't do this:**
```csharp
// Loads ALL customers into memory first!
var customers = _context.Customers.ToList();
var filtered = customers.Where(c => c.Name.Contains(name));
```

**Do this instead:**
```csharp
// Filters on database side
var customers = await _context.Customers
    .Where(c => c.Name.Contains(name))
    .ToListAsync();
```

## Bonus Challenges

1. **Add custom validation**: Implement IValidatableObject on entities
2. **Add auditing**: Create CreatedDate and ModifiedDate fields
3. **Implement soft delete**: Add IsDeleted flag instead of hard delete
4. **Add global query filters**: Automatically filter soft-deleted records
5. **Implement caching**: Use IMemoryCache for frequently accessed data
6. **Add logging**: Log all SQL queries generated by EF Core
7. **Optimize queries**: Use SQL Server Profiler to analyze generated SQL

## Need Help?

- Review TODO comments in each file
- Check EF Core documentation: https://learn.microsoft.com/ef/core/
- Examine existing entity classes for hints
- Use Swagger UI to test endpoints
- Check SQL Server logs for database errors

Good luck!

