using System;
using System.Text.Json.Serialization;

namespace LibrarySystem.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int CopyId { get; set; }
        public Copy? Copy { get; set; }

        public int UserId { get; set; }

        [JsonIgnore] // rompe ciclo con User
        public User? User { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Loan(int copyId, DateTime loanDate)
        {
            CopyId = copyId;
            LoanDate = loanDate;
        }
    }
}
