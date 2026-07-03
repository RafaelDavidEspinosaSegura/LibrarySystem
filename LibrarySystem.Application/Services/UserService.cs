using LibrarySystem.Application.Interfaces;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _userRepository.GetAllAsync();
        public async Task<User?> GetByIdAsync(int id) => await _userRepository.GetByIdAsync(id);
        public async Task AddAsync(User user) => await _userRepository.AddAsync(user);
        public async Task UpdateAsync(User user) => await _userRepository.UpdateAsync(user);
        public async Task DeleteAsync(int id) => await _userRepository.DeleteAsync(id);
    }
}
