using System.Text.Json;
using BlazorSchool.Models;
namespace BlazorSchool.Data
{
    public class JsonFileDatabase
    {
        private const string FilePath = "database.json";

        public async Task<List<Student>> GetAllStudents()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Student>();
            }

            var json = await File.ReadAllTextAsync(FilePath);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }

        public async Task SaveAllStudents(List<Student> students)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(students, options);
            await File.WriteAllTextAsync(FilePath, json);
        }
    }
}
