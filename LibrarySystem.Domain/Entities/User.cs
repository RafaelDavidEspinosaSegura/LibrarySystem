using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibrarySystem.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string passwordHash { get; set; }
        public string Role { get; set; } = "Lector";

        [JsonIgnore] // rompe ciclo con Loan
        public List<Loan> Loans { get; set; } = new List<Loan>();

        [JsonIgnore] // rompe ciclo con Reservation
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
