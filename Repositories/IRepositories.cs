using EfCoreLab.Data;

namespace EfCoreLab.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(long id, bool includeRelated = false);
        Task<Customer?> GetByEmailAsync(string email);
        Task<IEnumerable<Customer>> GetAllAsync(bool includeRelated = false);
        Task<IEnumerable<Customer>> GetAllWithSplitQueriesAsync();
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(long id);
        Task<bool> ExistsAsync(long id);
        Task<bool> EmailExistsAsync(string email, long? excludeCustomerId = null);
        
        // Pagination support
        Task<(IEnumerable<Customer> Items, int TotalCount)> GetPagedAsync(int page, int pageSize, bool includeRelated = false);
        
        // Search and filtering
        Task<IEnumerable<Customer>> SearchAsync(string? name, string? email, decimal? minBalance);
        
        // Efficient read-only queries
        Task<IEnumerable<Customer>> GetAllNoTrackingAsync();
    }

    public interface IInvoiceRepository
    {
        Task<Invoice?> GetByIdAsync(long id);
        Task<Invoice?> GetByInvoiceNumberAsync(string invoiceNumber);
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<IEnumerable<Invoice>> GetByCustomerIdAsync(long customerId);
        Task<Invoice> CreateAsync(Invoice invoice);
        Task<Invoice> UpdateAsync(Invoice invoice);
        Task<bool> DeleteAsync(long id);
        Task<bool> ExistsAsync(long id);
        Task<bool> InvoiceNumberExistsAsync(string invoiceNumber, long? excludeInvoiceId = null);
    }

    public interface ITelephoneNumberRepository
    {
        Task<TelephoneNumber?> GetByIdAsync(long id);
        Task<IEnumerable<TelephoneNumber>> GetAllAsync();
        Task<IEnumerable<TelephoneNumber>> GetByCustomerIdAsync(long customerId);
        Task<TelephoneNumber> CreateAsync(TelephoneNumber telephoneNumber);
        Task<TelephoneNumber> UpdateAsync(TelephoneNumber telephoneNumber);
        Task<bool> DeleteAsync(long id);
        Task<bool> ExistsAsync(long id);
    }
}
