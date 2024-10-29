using DomainModels;

namespace RepositoryLayer
{
    public interface IStudentRepo
    {
        Task<Student> SaveStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int studentId);
        Task<Student> GetStudentById(int studentId);
        Task<List<Student>> GetStudentList();
        Task<List<Student>> GetStudentsByCourseId(int courseId);
    }
}
