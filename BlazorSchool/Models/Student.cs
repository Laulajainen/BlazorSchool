using System.ComponentModel.DataAnnotations;
namespace BlazorSchool.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, MinLength(2)]
        public string? FirstName { get; set; }

        [Required, MinLength(2)]
        public string? LastName { get; set; }

        [Required, Range(typeof(DateTime), "1910/1/1", "2014/1/1", ErrorMessage = "You must be at least 10 years old.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@edu\.tucsweden\.se$", ErrorMessage = "Invalid email format. Only @edu.tucsweden.se domain is allowed for email.")]
        public string? Email { get; set; }
    }
}
