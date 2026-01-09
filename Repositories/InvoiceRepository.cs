using EfCoreLab.Data;

namespace EfCoreLab.Repositories
{
    /// <summary>
    /// TODO: Students should implement this repository with EF Core
    /// 
    /// LEARNING FOCUS:
    /// - Basic CRUD operations
    /// - Filtering by foreign key (GetByCustomerIdAsync)
    /// - Unique constraint validation (InvoiceNumberExistsAsync)
    /// </summary>
    public class InvoiceRepository : IInvoiceRepository
    {
        // TODO: Inject AppDbContext

        public async Task<Invoice?> GetByIdAsync(long id)
        {
            throw new NotImplementedException("Students: Implement with EF Core");
        }

        public async Task<Invoice?> GetByInvoiceNumberAsync(string invoiceNumber)
        {
            throw new NotImplementedException("Students: Implement with EF Core");
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            throw new NotImplementedException("Students: Implement with EF Core");
        }

        // TODO: Filter invoices by customer
        // Hint: Use Where clause with CustomerId
        public async Task<IEnumerable<Invoice>> GetByCustomerIdAsync(long customerId)
        {
            throw new NotImplementedException("Students: Implement filtering by CustomerId");
        }

        public async Task<Invoice> CreateAsync(Invoice invoice)
        {
            throw new NotImplementedException("Students: Implement Create operation");
        }

        public async Task<Invoice> UpdateAsync(Invoice invoice)
        {
            throw new NotImplementedException("Students: Implement Update operation");
        }

        public async Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException("Students: Implement Delete operation");
        }

        public async Task<bool> ExistsAsync(long id)
        {
            throw new NotImplementedException("Students: Implement with AnyAsync");
        }

        public async Task<bool> InvoiceNumberExistsAsync(string invoiceNumber, long? excludeInvoiceId = null)
        {
            throw new NotImplementedException("Students: Implement uniqueness check");
        }
    }
}
