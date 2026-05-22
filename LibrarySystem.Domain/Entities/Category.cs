using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibrarySystem.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        [JsonIgnore] // rompe ciclo con Book
        public List<Book> Books { get; set; } = new List<Book>();

        public Category(string name)
        {
            Name = name;
        }
    }
}
