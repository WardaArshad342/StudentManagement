using DomainModels;
using RepositoryLayer;

namespace ServiceLayer
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo _courseRepo;
        public CourseService(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public async Task<bool> DeleteCourse(int courseId)
        {
            return await _courseRepo.DeleteCourse(courseId);
        }

        public async Task<Course> GetCourseById(int courseId)
        {
            return await _courseRepo.GetCourseById(courseId);
        }

        public async Task<List<Course>> GetCourseList()
        {
            return await _courseRepo.GetCourseList();
        }

        public async Task<List<Course>> GetCoursesByStudentId(int courseId)
        {
            return await _courseRepo.GetCoursesByStudentId(courseId);
        }

        public async Task<Course> SaveCourse(Course Course)
        {
            return await _courseRepo.SaveCourse(Course);
        }

        public async Task<Course> UpdateCourse(Course Course)
        {
            return await _courseRepo.UpdateCourse(Course);
        }
    }
}
