using LibrarySystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan?> GetByIdAsync(int id);
        Task<IEnumerable<Loan>> GetAllAsync();
        Task AddAsync(Loan loan);
        Task UpdateAsync(Loan loan);
        Task DeleteAsync(int id);
    }
}
