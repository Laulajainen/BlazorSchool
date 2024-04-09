using BlazorSchool.Models;
namespace BlazorSchool.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task DeleteStudent(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> GetStudentById(int id);
    }
}