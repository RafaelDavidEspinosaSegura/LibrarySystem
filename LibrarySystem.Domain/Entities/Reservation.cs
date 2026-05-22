using System;
using System.Text.Json.Serialization;

namespace LibrarySystem.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CopyId { get; set; }
        public Copy? Copy { get; set; }

        public int UserId { get; set; }

        [JsonIgnore] // rompe ciclo con User
        public User? User { get; set; }

        public DateTime ReservationDate { get; set; }

        public Reservation(int copyId, DateTime reservationDate)
        {
            CopyId = copyId;
            ReservationDate = reservationDate;
        }
    }
}
