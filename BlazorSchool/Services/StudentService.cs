using BlazorSchool.Models;
using BlazorSchool.Data;

namespace BlazorSchool.Services
{
    public class StudentService : IStudentService
    {
        private readonly JsonFileDatabase _database;

        public StudentService(JsonFileDatabase database)
        {
            _database = database;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _database.GetAllStudents();
        }

        public async Task DeleteStudent(int id)
        {
            var students = await _database.GetAllStudents();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                await _database.SaveAllStudents(students);
            }
        }

        public async Task<Student> AddStudent(Student student)
        {
            var students = await _database.GetAllStudents();
            student.Id = students.Any() ? students.Max(s => s.Id) + 1 : 1;
            students.Add(student);
            await _database.SaveAllStudents(students);
            return student;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var students = await _database.GetAllStudents();
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent == null)
            {
                throw new Exception($"Student with ID {student.Id} not found");
            }
            students.Remove(existingStudent);
            students.Add(student);
            await _database.SaveAllStudents(students);
            return student;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var students = await _database.GetAllStudents();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new Exception($"Student with ID {id} not found");
            }
            return student;
        }
    }
}