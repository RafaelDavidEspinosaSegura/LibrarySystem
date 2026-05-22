using LibrarySystem.Domain.Entities;
using Xunit;

namespace LibrarySystem.Application.Tests
{
    public class LoanTests
    {
        [Fact]
        public void Loan_Should_Set_LoanDate()
        {
            var loanDate = DateTime.Now;
            var loan = new Loan(copyId: 1, loanDate);

            Assert.Equal(loanDate, loan.LoanDate);
        }

        [Fact]
        public void Loan_Should_Allow_ReturnDate()
        {
            var loan = new Loan(copyId: 1, DateTime.Now);
            loan.ReturnDate = DateTime.Now.AddDays(2);

            Assert.NotNull(loan.ReturnDate);
        }
    }
}
