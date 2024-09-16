namespace Alansar.Core.Models
{
    //public class RegisterModel
    //{
    //}
    public record struct RegisterModel(string FirstName, string LastName, string Class, string? MiddleName, string Email, string Password, string ConfirmPassword, DateTime? DateOfBirth);

}
