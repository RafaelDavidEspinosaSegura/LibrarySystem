using LibrarySystem.Application.Interfaces;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync() => await _reservationRepository.GetAllAsync();
        public async Task<Reservation?> GetByIdAsync(int id) => await _reservationRepository.GetByIdAsync(id);
        public async Task AddAsync(Reservation reservation) => await _reservationRepository.AddAsync(reservation);
        public async Task UpdateAsync(Reservation reservation) => await _reservationRepository.UpdateAsync(reservation);
        public async Task DeleteAsync(int id) => await _reservationRepository.DeleteAsync(id);
    }
}
