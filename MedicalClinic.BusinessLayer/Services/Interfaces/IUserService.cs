using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> CreateNewUserAsync(UserDto user);

        public Task<List<UserDto>> GetAllUsersAsync();

        public Task DeleteAsync(int id);

        public Task<UserDto> EditAsync(UserDto user);

        public Task<UserDto> GetUserByIdAsync(int id);
    }
}



