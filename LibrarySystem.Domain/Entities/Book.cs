using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibrarySystem.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public required string ISBN { get; set; }

        public List<Author> Authors { get; set; } = new List<Author>();
        public Category? Category { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public List<Copy> Copies { get; set; } = new List<Copy>();

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        public Book(string title, string iSBN, DateTime publicationDate, int categoryId)
        {
            Title = title;
            ISBN = iSBN;
            PublicationDate = publicationDate;
            CategoryId = categoryId;
        }

        public Book() { }
    }
}
