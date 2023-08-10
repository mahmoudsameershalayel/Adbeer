using Adbeer.Dto.StudentDto;

namespace Adbeer.Service.UserService
{
    public interface IUserService
    {
        public Task<CreateStudentDto> CreateStudent();
    }
}
