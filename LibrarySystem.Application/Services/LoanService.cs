using LibrarySystem.Application.Interfaces;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.Services
{
    public class LoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync() => await _loanRepository.GetAllAsync();
        public async Task<Loan?> GetByIdAsync(int id) => await _loanRepository.GetByIdAsync(id);
        public async Task AddAsync(Loan loan) => await _loanRepository.AddAsync(loan);
        public async Task UpdateAsync(Loan loan) => await _loanRepository.UpdateAsync(loan);
        public async Task DeleteAsync(int id) => await _loanRepository.DeleteAsync(id);
    }
}
