using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models.School;

namespace WebApplication2.Repositories
{
    public interface ISchoolRepository
    {
        Task<Student> GetStudentAsync(int id);
        Task<Student> AddStudentAsync(Student student);
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task DeleteStudnetAsync(int id);
        Task<Student> UpdateStudentAsync(Student student);
    }
}