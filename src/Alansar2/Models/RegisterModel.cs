namespace Alansar.Models
{
    public record struct RegisterModel(string FirstName, string LastName, string? MiddleName, string Email, string Class, string Password, string ConfirmPassword, DateTime? DateOfBirth);

}
