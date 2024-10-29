using DomainModels;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryLayer
{
    public class StudentRepo : IStudentRepo
    {
        public async Task<Student> SaveStudent(Student student)
        {
            try
            {
                string execCommand = "stp_Student";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@StudentId", student.StudentId));
                _sql.Parameters.Add(new SqlParameter("@Firstname", student.Firstname));
                _sql.Parameters.Add(new SqlParameter("@Surname", student.Surname));
                _sql.Parameters.Add(new SqlParameter("@DOB", student.DOB));
                _sql.Parameters.Add(new SqlParameter("@Gender", student.Gender));
                _sql.Parameters.Add(new SqlParameter("@Address1", student.Address1));
                _sql.Parameters.Add(new SqlParameter("@Address2", student.Address2));
                _sql.Parameters.Add(new SqlParameter("@Address3", student.Address3));
                _sql.Parameters.Add(new SqlParameter("@Val", 1));
                DataTable dt_Save = await DbConnection.Instance.ExecuteAsync(_sql);
                if (dt_Save.Rows.Count > 0)
                {
                    student.StudentId = Convert.IsDBNull(dt_Save.Rows[0]["Id"]) ? 0 : Convert.ToInt32(dt_Save.Rows[0]["Id"]);
                }
                return student;
            }
            catch (SqlException ex)
            {
                if (ex.State == 101)
                {
                    throw;
                }
                throw;
            }
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            try
            {
                string execCommand = "stp_Student";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@StudentId", student.StudentId));
                _sql.Parameters.Add(new SqlParameter("@Firstname", student.Firstname));
                _sql.Parameters.Add(new SqlParameter("@Surname", student.Surname));
                _sql.Parameters.Add(new SqlParameter("@DOB", student.DOB));
                _sql.Parameters.Add(new SqlParameter("@Gender", student.Gender));
                _sql.Parameters.Add(new SqlParameter("@Address1", student.Address1));
                _sql.Parameters.Add(new SqlParameter("@Address2", student.Address2));
                _sql.Parameters.Add(new SqlParameter("@Address3", student.Address3));
                _sql.Parameters.Add(new SqlParameter("@Val", 7));
                DataTable dt_Update = await DbConnection.Instance.ExecuteAsync(_sql);

                if (dt_Update.Rows.Count > 0)
                {
                    student.StudentId = Convert.IsDBNull(dt_Update.Rows[0]["Id"]) ? 0 : Convert.ToInt32(dt_Update.Rows[0]["Id"]);
                }
                return student;
            }
            catch (SqlException ex)
            {
                if (ex.State == 101)
                {
                    throw;
                }
                throw;
            }
        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            bool val = false;
            try
            {
                string execCommand = "stp_Student";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@studentId", studentId));
                _sql.Parameters.Add(new SqlParameter("@Val", 2));
                DataTable dt_1 = await DbConnection.Instance.ExecuteAsync(_sql);
                if (dt_1.Rows.Count > 0)
                {
                    val = true;
                }
                return val;
            }
            catch (SqlException ex)
            {
                if (ex.State == 101)
                {
                    throw;
                }
                throw;
            }
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            try
            {
                string execCommand = "stp_Student";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@studentId", studentId));
                _sql.Parameters.Add(new SqlParameter("@Val", 3));
                DataTable dt_1 = await DbConnection.Instance.ExecuteAsync(_sql);
                Student student = new Student();
                if (dt_1.Rows.Count > 0)
                {
                    student = new Student
                    {
                        StudentId = Convert.IsDBNull(dt_1.Rows[0]["StudentId"]) ? 0 : Convert.ToInt32(dt_1.Rows[0]["StudentId"]),
                        Firstname = Convert.IsDBNull(dt_1.Rows[0]["Firstname"]) ? string.Empty : Convert.ToString(dt_1.Rows[0]["Firstname"]),
                        Surname = Convert.IsDBNull(dt_1.Rows[0]["Surname"]) ? string.Empty : Convert.ToString(dt_1.Rows[0]["Surname"]),
                        DOB = Convert.ToDateTime(dt_1.Rows[0]["dob"]),
                        Gender = Convert.IsDBNull(dt_1.Rows[0]["Gender"]) ? 0 : Convert.ToInt32(dt_1.Rows[0]["Gender"]),
                        Address1 = Convert.IsDBNull(dt_1.Rows[0]["Address1"]) ? string.Empty : Convert.ToString(dt_1.Rows[0]["Address1"]),
                        Address2 = Convert.IsDBNull(dt_1.Rows[0]["Address2"]) ? string.Empty : Convert.ToString(dt_1.Rows[0]["Address2"]),
                        Address3 = Convert.IsDBNull(dt_1.Rows[0]["Address3"]) ? string.Empty : Convert.ToString(dt_1.Rows[0]["Address3"]),
                    };
                }
                return student;
            }
            catch (SqlException ex)
            {
                if (ex.State == 101)
                {
                    throw;
                }
                throw;
            }
        }

        public async Task<List<Student>> GetStudentList()
        {
            try
            {
                string execCommand = "stp_Student";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@Val", 4));
                DataTable dt_1 = await DbConnection.Instance.ExecuteAsync(_sql);
                List<Student> students = new List<Student>();
                if (dt_1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_1.Rows)
                    {
                        var student = new Student
                        {
                            StudentId = Convert.IsDBNull(dr["StudentId"]) ? 0 : Convert.ToInt32(dr["StudentId"]),
                            Firstname = Convert.IsDBNull(dr["Firstname"]) ? string.Empty : Convert.ToString(dr["Firstname"]),
                            Surname = Convert.IsDBNull(dr["Surname"]) ? string.Empty : Convert.ToString(dr["Surname"]),
                            DOB = Convert.ToDateTime(dr["dob"]),
                            Gender = Convert.IsDBNull(dr["Gender"]) ? 0 : Convert.ToInt32(dr["Gender"]),
                            Address1 = Convert.IsDBNull(dr["Address1"]) ? string.Empty : Convert.ToString(dr["Address1"]),
                            Address2 = Convert.IsDBNull(dr["Address2"]) ? string.Empty : Convert.ToString(dr["Address2"]),
                            Address3 = Convert.IsDBNull(dr["Address3"]) ? string.Empty : Convert.ToString(dr["Address3"]),
                        };
                        students.Add(student);
                    }
                }
                return students;
            }
            catch (SqlException ex)
            {
                if (ex.State == 101)
                {
                    throw;
                }
                throw;
            }
        }

        public async Task<List<Student>> GetStudentsByCourseId(int courseId)
        {
            try
            {
                string execCommand = "stp_Course";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@CourseId", courseId));
                _sql.Parameters.Add(new SqlParameter("@Val", 5));
                DataTable dt_1 = await DbConnection.Instance.ExecuteAsync(_sql);
                List<Student> students = new List<Student>();
                if (dt_1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_1.Rows)
                    {
                        var student = new Student
                        {
                            StudentId = Convert.IsDBNull(dr["StudentId"]) ? 0 : Convert.ToInt32(dr["StudentId"]),
                            Firstname = Convert.IsDBNull(dr["Firstname"]) ? string.Empty : Convert.ToString(dr["Firstname"]),
                            Surname = Convert.IsDBNull(dr["Surname"]) ? string.Empty : Convert.ToString(dr["Surname"]),
                            DOB = Convert.ToDateTime(dr["dob"]),
                            Gender = Convert.IsDBNull(dr["Gender"]) ? 0 : Convert.ToInt32(dr["Gender"]),
                            Address1 = Convert.IsDBNull(dr["Address1"]) ? string.Empty : Convert.ToString(dr["Address1"]),
                            Address2 = Convert.IsDBNull(dr["Address2"]) ? string.Empty : Convert.ToString(dr["Address2"]),
                            Address3 = Convert.IsDBNull(dr["Address3"]) ? string.Empty : Convert.ToString(dr["Address3"]),
                        };
                        students.Add(student);
                    }
                }
                return students;
            }
            catch (SqlException ex)
            {
                if (ex.State == 101)
                {
                    throw;
                }
                throw;
            }
        }

    }
}
