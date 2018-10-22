using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models.School;

namespace WebApplication2.Services
{
    public interface ISchoolService
    {
        Task<Student> GetStudentAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task DeleteStudentAsync(int id);
        Task<Student> UpdateStudentAsync(Student student);
    }
}