using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
    public class StudentViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }

        public int Id { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = ("Studnet Name is required.")), RegularExpression(@"^[a-zA-Z]*$", ErrorMessage ="Only alphabetic characters are allowed.")]
        public string Name { get; set; }
    }
}