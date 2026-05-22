using System;
using System.Text.Json.Serialization;

namespace LibrarySystem.Domain.Entities
{
    public class Copy
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        [JsonIgnore] // rompe ciclo con Book
        public Book? Book { get; set; }

        public bool IsAvailable { get; set; }

        public Copy(int bookId, bool isAvailable = true)
        {
            BookId = bookId;
            IsAvailable = isAvailable;
        }
    }
}
