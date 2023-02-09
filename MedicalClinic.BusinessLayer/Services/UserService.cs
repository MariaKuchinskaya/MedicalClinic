using EfWebTutorial.Interfaces;
using EfWebTutorial.Repositories;
using MedicalClinic.DAL.Repositories;
using MedicalClinic.Models;

namespace EfWebTutorial.Services
{
    public class UserService : IUserService
    {
        UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            userRepository = _userRepository;
        }

        public async Task<User> CreateNewUser(User user)
        {
            return await _userRepository.CreateAsync(user);

        }

        public async Task<List<User>> GetAllUsers()
        {
            var res = await _userRepository.GetAllItemsAsync();
            return res;
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);

        }


        public async Task<User> EditAsync(User user)
        {
            return await _userRepository.EditAsync(user);
        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetItemAsync(id);
            return user;

        }
    }
}
