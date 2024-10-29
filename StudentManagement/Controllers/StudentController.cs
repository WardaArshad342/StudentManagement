using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentController(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetStudentList();
            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.GenderList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Male" },
                new SelectListItem { Value = "2", Text = "Female" }
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (student.Firstname != "")
            {
                await _studentService.SaveStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentById(id); // Assuming you have a service layer
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.GenderList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Male", Selected = student.Gender == 1 },
                new SelectListItem { Value = "2", Text = "Female", Selected = student.Gender == 2 }
            };

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (student != null)
            {
                await _studentService.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(Student student)
        {
            var deleted = await _studentService.DeleteStudent(student.StudentId);
            if (!deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AssignCourses(int studentId)
        {
            var student = await _studentService.GetStudentById(studentId);
            if (student == null)
                return NotFound();

            var courses = await _courseService.GetCourseList();
            ViewBag.CourseList = new MultiSelectList(courses, "CourseId", "Name");

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> AssignCourses(Student student, List<int> selectedCourseIds)
        {
            if (selectedCourseIds == null)
                selectedCourseIds = new List<int>();

            await _studentService.AssignCoursesToStudent(student, selectedCourseIds);

            return RedirectToAction("Index");
        }

    }
}
