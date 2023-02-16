using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> CreateNewUser(UserDto user);

        public Task<List<UserDto>> GetAllUsers();

        public Task DeleteAsync(int id);
        public Task<UserDto> EditAsync(UserDto user);

        public Task<UserDto> GetUserByIdAsync(int id);
    }
}



