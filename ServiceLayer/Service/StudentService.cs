using DomainModels;
using RepositoryLayer;

namespace ServiceLayer
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;
        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            return await _studentRepo.DeleteStudent(studentId);
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _studentRepo.GetStudentById(studentId);
        }

        public async Task<List<Student>> GetStudentList()
        {
            return await _studentRepo.GetStudentList();
        }

        public async Task<List<Student>> GetStudentsByCourseId(int courseId)
        {
            return await _studentRepo.GetStudentsByCourseId(courseId);
        }

        public async Task<Student> SaveStudent(Student student)
        {
            return await _studentRepo.SaveStudent(student);
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            return await _studentRepo.UpdateStudent(student);
        }

        public async Task<Student> AssignCoursesToStudent(Student student, List<int> courseIds)
        {
            return await _studentRepo.AssignCoursesToStudent(student, courseIds);
        }
    }
}
