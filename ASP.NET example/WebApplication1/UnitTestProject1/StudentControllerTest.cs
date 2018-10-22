using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication2.Controllers;
using WebApplication2.Models.School;
using WebApplication2.Repositories;
using WebApplication2.Services;
using WebApplication2.ViewModels;

namespace UnitTestProject1
{
    [TestClass]
    public class StudentControllerTest
    {
        private Mock<ISchoolRepository> _schoolRepositoryMock;
        private Mock<ISchoolService> _schoolServiceMock;

        [TestInitialize]
        public void Init()
        {
            _schoolRepositoryMock = new Mock<ISchoolRepository>();
            _schoolServiceMock = new Mock<ISchoolService>();
        }

        [TestMethod]
        public async Task AddStudent()
        {
            _schoolServiceMock.Setup(d => d.AddStudentAsync(It.IsAny<Student>())).Returns(Task.Run(()=> new Student { StudentId = 1, StudentName = "Valentin" }));

            var httpContextMock = new Mock<HttpContextBase>();
            var httpReguestMock = new Mock<HttpRequestBase>();
            var httpResponseMock = new Mock<HttpResponseBase>();

            httpContextMock.SetupGet(c => c.Response).Returns(httpResponseMock.Object);
            httpContextMock.SetupGet(c => c.Request).Returns(httpReguestMock.Object);
            
            var schoolController = new StudentController(_schoolServiceMock.Object);
            
            schoolController.ControllerContext = new ControllerContext(httpContextMock.Object, new RouteData(), schoolController);
            schoolController.Url = new UrlHelper(new RequestContext(schoolController.HttpContext, new RouteData()));
            
            var result = (await schoolController.AddNewStudent(new StudentViewModel { Id = 0, Name = "test" }, @"Student\Index")) as RedirectToRouteResult;

            Assert.AreEqual("Student", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
