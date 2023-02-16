using AutoMapper;
using MedicalClinic.DAL.Repositories;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Services.Interfaces;

namespace MedicalClinic.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateNewUserAsync(UserDto userDto)
        {
            var user =  _mapper.Map<User>(userDto);
            var result =  await _userRepository.CreateAsync(user);

            return _mapper.Map<UserDto>(result);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var result = await _userRepository.GetAllItemsAsync();
            return _mapper.Map<List<UserDto>>(result);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }


        public async Task<UserDto> EditAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result =  await _userRepository.EditAsync(user);

            return _mapper.Map<UserDto>(result);
        }


        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetItemAsync(id);

            return _mapper.Map<UserDto>(user);
        }
    }
}
