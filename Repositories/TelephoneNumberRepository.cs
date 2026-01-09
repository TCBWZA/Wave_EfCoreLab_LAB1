using EfCoreLab.Data;

namespace EfCoreLab.Repositories
{
    /// <summary>
    /// TODO: Students should implement this repository with EF Core
    /// 
    /// LEARNING FOCUS:
    /// - Basic CRUD operations
    /// - Filtering by foreign key
    /// </summary>
    public class TelephoneNumberRepository : ITelephoneNumberRepository
    {
        // TODO: Inject AppDbContext

        public async Task<TelephoneNumber?> GetByIdAsync(long id)
        {
            throw new NotImplementedException("Students: Implement with EF Core");
        }

        public async Task<IEnumerable<TelephoneNumber>> GetAllAsync()
        {
            throw new NotImplementedException("Students: Implement with EF Core");
        }

        public async Task<IEnumerable<TelephoneNumber>> GetByCustomerIdAsync(long customerId)
        {
            throw new NotImplementedException("Students: Implement filtering by CustomerId");
        }

        public async Task<TelephoneNumber> CreateAsync(TelephoneNumber telephoneNumber)
        {
            throw new NotImplementedException("Students: Implement Create operation");
        }

        public async Task<TelephoneNumber> UpdateAsync(TelephoneNumber telephoneNumber)
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
    }
}
