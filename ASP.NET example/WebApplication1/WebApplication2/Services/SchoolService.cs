using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models.School;
using WebApplication2.Repositories;

namespace WebApplication2.Services
{
    public class SchoolService : ISchoolService
    { 
        private readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            return await _schoolRepository.AddStudentAsync(student);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _schoolRepository.GetStudentsAsync();
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            return await _schoolRepository.GetStudentAsync(id);
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            return await _schoolRepository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _schoolRepository.DeleteStudnetAsync(id);
        }
    } 
}