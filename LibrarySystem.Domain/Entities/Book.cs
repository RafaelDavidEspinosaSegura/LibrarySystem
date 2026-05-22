using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema; // Requerido para [NotMapped]
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

        [JsonIgnore] // rompe ciclo con Copy
        public List<Copy> Copies { get; set; } = new List<Copy>();

        [NotMapped] // Ignora esta propiedad en la base de datos
        public object Loans { get; set; }

        [NotMapped] // Ignora esta propiedad en la base de datos
        public object Reservations { get; set; }

        public Book(string title, string iSBN, DateTime publicationDate, int categoryId)
        {
            Title = title;
            ISBN = iSBN;
            PublicationDate = publicationDate;
            CategoryId = categoryId;
        }
    }
}
