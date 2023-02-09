using MedicalClinic.Models;

namespace EfWebTutorial.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateNewUser(User user);

        public Task<List<User>> GetAllUsers();

        public Task DeleteAsync(int id);
        public Task<User> EditAsync(User user);

        public Task<User> GetUserByIdAsync(int id);


    }
}