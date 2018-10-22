using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication2.Models.School;
using WebApplication2.Services;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
   //[Authorize]
    public class StudentController : Controller
    {
        private readonly ISchoolService _schoolService;

        public StudentController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        
        public async Task<ActionResult> Index()
        {
            var students = await _schoolService.GetStudentsAsync();

            return View(students);
        }

        public ActionResult AddStudent()
        {
            var studentViewModel = new StudentViewModel
            {
                Title = "Add New Student",
                AddButtonTitle = "Add",
                RedirectUrl = Url.Action("Index", "Student")
            };

            return View(studentViewModel);
        }

        public async Task<ActionResult> DetailsOfStudent(int id)
        {
            var student = await _schoolService.GetStudentAsync(id);

            return View(new StudentViewModel { Id = student.StudentId,  Name = student.StudentName });
        }

        [HttpPost]
        public async Task<ActionResult> SaveStudent(StudentViewModel studentViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(studentViewModel);
            }

            var student = await _schoolService.GetStudentAsync(studentViewModel.Id);
            if (student != null)
            {
                student.StudentName = studentViewModel.Name;

                await _schoolService.UpdateStudentAsync(student);
            }
            
            return RedirectToLocal(redirectUrl);
        }

        public async Task<ActionResult> EditStudent(int id)
        {
            var student = await _schoolService.GetStudentAsync(id);

            var studentViewModel = new StudentViewModel
            {
                Title = "Edit Student",
                AddButtonTitle = "Save",
                RedirectUrl = Url.Action("Index", "Student"),
                Name = student.StudentName,
                Id = student.StudentId
            };

            return View(studentViewModel);
        }

        public async Task<ActionResult> DeleteStudent(int id)
        {
            await _schoolService.DeleteStudentAsync(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> AddNewStudent(StudentViewModel studentViewModel, string redirectUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(studentViewModel);
            }

            var student = new Student
            {
                StudentName = studentViewModel.Name
            };

            await _schoolService.AddStudentAsync(student);

            return RedirectToLocal(redirectUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Student");
        }
    }
}