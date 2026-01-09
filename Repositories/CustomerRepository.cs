using EfCoreLab.Data;

namespace EfCoreLab.Repositories
{
    /// <summary>
    /// TODO: Students should implement this repository with EF Core
    /// 
    /// LAB LEARNING OBJECTIVES:
    /// 1. Basic CRUD operations
    /// 2. Include related entities (.Include)
    /// 3. Pagination (Skip/Take)
    /// 4. Dynamic filtering (Where)
    /// 5. Read-only queries (AsNoTracking)
    /// 6. Split queries (AsSplitQuery)
    /// 7. Async operations
    /// 
    /// IMPLEMENTATION HINTS:
    /// - Inject AppDbContext in constructor
    /// - Use async/await for all database operations
    /// - Use FirstOrDefaultAsync for single items
    /// - Use ToListAsync to execute queries
    /// - Always use OrderBy before Skip/Take
    /// - Use AsNoTracking for read-only queries
    /// - Use Include for eager loading related entities
    /// - Use AsSplitQuery to avoid cartesian explosion with multiple collections
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        // TODO: Inject AppDbContext
        
        // TODO: Implement GetByIdAsync
        // Hint: Use FirstOrDefaultAsync, conditionally Include related entities
        public async Task<Customer?> GetByIdAsync(long id, bool includeRelated = false)
        {
            throw new NotImplementedException("Students: Implement with EF Core");
        }

        // TODO: Implement GetByEmailAsync
        // Hint: Use FirstOrDefaultAsync with Where clause
        public async Task<Customer?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException("Students: Implement with EF Core");
        }

        // TODO: Implement GetAllAsync
        // Hint: Use ToListAsync, conditionally Include related entities
        public async Task<IEnumerable<Customer>> GetAllAsync(bool includeRelated = false)
        {
            throw new NotImplementedException("Students: Implement with EF Core");
        }

        // TODO: Implement GetAllWithSplitQueriesAsync
        // Hint: Use AsSplitQuery() before Include to avoid cartesian explosion
        // This executes separate SQL queries for each collection (Invoices, PhoneNumbers)
        public async Task<IEnumerable<Customer>> GetAllWithSplitQueriesAsync()
        {
            throw new NotImplementedException("Students: Implement with AsSplitQuery()");
        }

        // TODO: Implement GetPagedAsync
        // Hint: 
        // 1. Get total count first with CountAsync()
        // 2. Use OrderBy() before Skip/Take
        // 3. Skip((page - 1) * pageSize)
        // 4. Take(pageSize)
        public async Task<(IEnumerable<Customer> Items, int TotalCount)> GetPagedAsync(
            int page, 
            int pageSize, 
            bool includeRelated = false)
        {
            throw new NotImplementedException("Students: Implement pagination with Skip/Take");
        }

        // TODO: Implement SearchAsync
        // Hint: Build query dynamically using Where clauses
        // - Use Contains for LIKE searches
        // - Check if parameters have values before adding Where
        // - For minBalance, filter based on sum of related invoices
        public async Task<IEnumerable<Customer>> SearchAsync(
            string? name, 
            string? email, 
            decimal? minBalance)
        {
            throw new NotImplementedException("Students: Implement dynamic filtering");
        }

        // TODO: Implement GetAllNoTrackingAsync
        // Hint: Use AsNoTracking() for read-only queries (better performance)
        public async Task<IEnumerable<Customer>> GetAllNoTrackingAsync()
        {
            throw new NotImplementedException("Students: Implement with AsNoTracking()");
        }

        // TODO: Implement CreateAsync
        // Hint: Use Add() then SaveChangesAsync()
        public async Task<Customer> CreateAsync(Customer customer)
        {
            throw new NotImplementedException("Students: Implement Create operation");
        }

        // TODO: Implement UpdateAsync
        // Hint: Use Update() then SaveChangesAsync()
        public async Task<Customer> UpdateAsync(Customer customer)
        {
            throw new NotImplementedException("Students: Implement Update operation");
        }

        // TODO: Implement DeleteAsync
        // Hint: Find entity first, then Remove(), then SaveChangesAsync()
        public async Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException("Students: Implement Delete operation");
        }

        // TODO: Implement ExistsAsync
        // Hint: Use AnyAsync with Where clause
        public async Task<bool> ExistsAsync(long id)
        {
            throw new NotImplementedException("Students: Implement with AnyAsync");
        }

        // TODO: Implement EmailExistsAsync
        // Hint: Use AnyAsync, exclude specific customer if updating
        public async Task<bool> EmailExistsAsync(string email, long? excludeCustomerId = null)
        {
            throw new NotImplementedException("Students: Implement email uniqueness check");
        }
    }
}
