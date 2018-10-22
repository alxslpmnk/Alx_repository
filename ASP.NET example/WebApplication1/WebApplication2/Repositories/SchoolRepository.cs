using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApplication2.Common;
using WebApplication2.Models.School;
using WebApplication2.Repositories;

namespace WebApplication2
{
    public class SchoolRepository : ISchoolRepository
    {
        public SchoolRepository()
        { }

        public async Task<Student> GetStudentAsync(int id)
        {
            Student result = null;

            using (var schoolContext = new SchoolContext())
            {
                result = await schoolContext.Students.FirstOrDefaultAsync(f=>f.StudentId == id);
            }

            return result;
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            Student result = null;

            using (var schoolContext = new SchoolContext())
            {
                result =schoolContext.Students.Add(student);
                await schoolContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            var result = new List<Student>();

            using (var schoolContext = new SchoolContext())
            {
                result = await schoolContext.Students.ToListAsync();
            }

            return result;
        }

        public async Task DeleteStudnetAsync(int id)
        {
            using (var schoolContext = new SchoolContext())
            {
                var student = await schoolContext.Students.FirstOrDefaultAsync(f => f.StudentId == id);

                schoolContext.Entry(student).State = EntityState.Deleted;

                await schoolContext.SaveChangesAsync();
            }
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            using (var schoolContext = new SchoolContext())
            {
                schoolContext.Entry(student).State = EntityState.Modified;

                await schoolContext.SaveChangesAsync();
            }

            return student;
        }
    }
}