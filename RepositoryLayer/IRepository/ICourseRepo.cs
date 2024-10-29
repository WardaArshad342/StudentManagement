using DomainModels;

namespace RepositoryLayer
{
    public interface ICourseRepo
    {
        Task<Course> SaveCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<bool> DeleteCourse(int courseId);
        Task<Course> GetCourseById(int courseId);
        Task<List<Course>> GetCourseList();
        Task<List<Course>> GetCoursesByStudentId(int studentId);
    }
}
