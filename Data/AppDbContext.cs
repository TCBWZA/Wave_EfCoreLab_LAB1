
namespace EfCoreLab.Data
{
    /// <summary>
    /// TODO: Students should implement the DbContext class
    /// 
    /// LAB INSTRUCTIONS:
    /// 1. Add EF Core NuGet packages to the project
    /// 2. Inherit from DbContext
    /// 3. Create DbSet properties for Customer, Invoice, and TelephoneNumber
    /// 4. Add a constructor that accepts DbContextOptions<AppDbContext>
    /// 5. Override OnModelCreating to configure entity relationships and constraints
    /// 
    /// REFERENCE CONFIGURATION:
    /// Customer:
    ///   - Primary Key: Id (auto-generated)
    ///   - Name: max length 200
    ///   - Email: max length 200, unique index
    ///   - Balance: computed property, should be ignored
    ///   - Has many Invoices (foreign key: CustomerId)
    ///   - Has many PhoneNumbers (foreign key: CustomerId)
    /// 
    /// Invoice:
    ///   - Primary Key: Id (auto-generated)
    ///   - InvoiceNumber: required, max length 50, unique index
    ///   - Amount: decimal(18,2), check constraint >= 0
    ///   - InvoiceDate: required
    ///   - CustomerId: required foreign key
    /// 
    /// TelephoneNumber:
    ///   - Primary Key: Id (auto-generated)
    ///   - Number: max length 50
    ///   - Type: max length 20, check constraint IN ('Mobile', 'Work', 'DirectDial')
    ///   - CustomerId: required foreign key
    /// </summary>
    public class AppDbContext
    { }
}
