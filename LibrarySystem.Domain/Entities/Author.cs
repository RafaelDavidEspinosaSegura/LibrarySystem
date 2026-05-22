using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibrarySystem.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }

        [JsonIgnore] // rompe ciclo con Book
        public List<Book> Books { get; set; } = new List<Book>();

        public Author(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}
