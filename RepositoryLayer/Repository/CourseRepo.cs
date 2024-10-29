using DomainModels;
using System.Data.SqlClient;
using System.Data;

namespace RepositoryLayer
{
    public class CourseRepo : ICourseRepo
    {
        public async Task<Course> SaveCourse(Course course)
        {
            try
            {
                string execCommand = "stp_Course";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@CourseId", course.CourseId));
                _sql.Parameters.Add(new SqlParameter("@Code", course.Code));
                _sql.Parameters.Add(new SqlParameter("@Name", course.Name));
                _sql.Parameters.Add(new SqlParameter("@TeacherName", course.TeacherName));
                _sql.Parameters.Add(new SqlParameter("@StartDate", course.StartDate));
                _sql.Parameters.Add(new SqlParameter("@EndDate", course.EndDate));
                _sql.Parameters.Add(new SqlParameter("@Val", 1));
                DataTable dt_Save =await DbConnection.Instance.ExecuteAsync(_sql);

                if (dt_Save.Rows.Count > 0)
                {
                    course.CourseId = Convert.IsDBNull(dt_Save.Rows[0]["Id"]) ? 0 : Convert.ToInt32(dt_Save.Rows[0]["Id"]);
                }
                return course;
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

        public async Task<Course> UpdateCourse(Course course)
        {
            try
            {
                string execCommand = "stp_Course";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@CourseId", course.CourseId));
                _sql.Parameters.Add(new SqlParameter("@Code", course.Code));
                _sql.Parameters.Add(new SqlParameter("@Name", course.Name));
                _sql.Parameters.Add(new SqlParameter("@TeacherName", course.TeacherName));
                _sql.Parameters.Add(new SqlParameter("@StartDate", course.StartDate));
                _sql.Parameters.Add(new SqlParameter("@EndDate", course.EndDate));
                _sql.Parameters.Add(new SqlParameter("@Val", 7));
                DataTable dt_Save =await DbConnection.Instance.ExecuteAsync(_sql);

                if (dt_Save.Rows.Count > 0)
                {
                    course.CourseId = Convert.IsDBNull(dt_Save.Rows[0]["Id"]) ? 0 : Convert.ToInt32(dt_Save.Rows[0]["Id"]);
                }
                return course;
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

        public async Task<bool> DeleteCourse(int courseId)
        {
            bool val = false;
            try
            {
                string execCommand = "stp_Course";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@courseId", courseId));
                _sql.Parameters.Add(new SqlParameter("@Val", 2));
                DataTable dt_1 =await DbConnection.Instance.ExecuteAsync(_sql);
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

        public async Task<Course> GetCourseById(int courseId)
        {
            try
            {
                string execCommand = "stp_Course";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@courseId", courseId));
                _sql.Parameters.Add(new SqlParameter("@Val", 3));
                DataTable dt_1 =await DbConnection.Instance.ExecuteAsync(_sql);
                Course course = new Course();
                if (dt_1.Rows.Count > 0)
                {
                    course = new Course
                    {
                        CourseId = Convert.IsDBNull(dt_1.Rows[0]["CourseId"]) ? 0 : Convert.ToInt32(dt_1.Rows[0]["CourseId"]),
                        Code = Convert.IsDBNull(dt_1.Rows[0]["Code"]) ? string.Empty : Convert.ToString(dt_1.Rows[0]["Code"]),
                        Name = Convert.IsDBNull(dt_1.Rows[0]["Name"]) ? string.Empty : Convert.ToString(dt_1.Rows[0]["Name"]),
                        TeacherName = Convert.IsDBNull(dt_1.Rows[0]["TeacherName"]) ? string.Empty : Convert.ToString(dt_1.Rows[0]["TeacherName"]),
                        StartDate = Convert.IsDBNull(dt_1.Rows[0]["StartDate"]) ? null : Convert.ToDateTime(dt_1.Rows[0]["StartDate"]),
                        EndDate = Convert.IsDBNull(dt_1.Rows[0]["EndDate"]) ? null : Convert.ToDateTime(dt_1.Rows[0]["EndDate"]),
                    };
                }
                return course;
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

        public async Task<List<Course>> GetCourseList()
        {
            try
            {
                string execCommand = "stp_Course";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@Val", 4));
                DataTable dt_1 =await DbConnection.Instance.ExecuteAsync(_sql);
                List<Course> courses = new List<Course>();
                if (dt_1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_1.Rows)
                    {
                        var course = new Course
                        {
                            CourseId = Convert.IsDBNull(dr["CourseId"]) ? 0 : Convert.ToInt32(dr["CourseId"]),
                            Code = Convert.IsDBNull(dr["Code"]) ? string.Empty : Convert.ToString(dr["Code"]),
                            Name = Convert.IsDBNull(dr["Name"]) ? string.Empty : Convert.ToString(dr["Name"]),
                            TeacherName = Convert.IsDBNull(dr["TeacherName"]) ? string.Empty : Convert.ToString(dr["TeacherName"]),
                            StartDate = Convert.IsDBNull(dr["StartDate"]) ? null : Convert.ToDateTime(dr["StartDate"]),
                            EndDate = Convert.IsDBNull(dr["EndDate"]) ? null : Convert.ToDateTime(dr["EndDate"]),
                        };
                        courses.Add(course);
                    }
                }
                return courses;
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

        public async Task<List<Course>> GetCoursesByStudentId(int studentId)
        {
            try
            {
                string execCommand = "stp_Course";
                SqlCommand _sql = await DbConnection.Instance.GetCommandAsync(execCommand, CommandType.StoredProcedure);
                _sql.Parameters.Add(new SqlParameter("@studentId", studentId));
                _sql.Parameters.Add(new SqlParameter("@Val", 5));
                DataTable dt_1 =await DbConnection.Instance.ExecuteAsync(_sql);
                List<Course> courses = new List<Course>();
                if (dt_1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_1.Rows)
                    {
                        var course = new Course
                        {
                            CourseId = Convert.IsDBNull(dr["CourseId"]) ? 0 : Convert.ToInt32(dr["CourseId"]),
                            Code = Convert.IsDBNull(dr["Code"]) ? string.Empty : Convert.ToString(dr["Code"]),
                            Name = Convert.IsDBNull(dr["Name"]) ? string.Empty : Convert.ToString(dr["Name"]),
                            TeacherName = Convert.IsDBNull(dr["TeacherName"]) ? string.Empty : Convert.ToString(dr["TeacherName"]),
                            StartDate = Convert.IsDBNull(dr["StartDate"]) ? null : Convert.ToDateTime(dr["StartDate"]),
                            EndDate = Convert.IsDBNull(dr["EndDate"]) ? null : Convert.ToDateTime(dr["EndDate"]),
                        };
                        courses.Add(course);
                    }
                }
                return courses;
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
