using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace C1
{
    public sealed record User(string Name, [Phone] string Number, [EmailAddress] string Email);
    public static class UserValidator
    {
        public static List<ValidationResult>? Validate(this User user)
        {
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(user, new ValidationContext(user), validationResults, true);
            return isValid ? default : validationResults;
        }
        public static bool IsValid(this User user) => Validate(user)?.Count == 0;
    }
    public static class UserRepository
    {
        private static HashSet<User> _users = new();
        private const string FilePath = "C:\\Users\\marcu\\Desktop\\H1\\Programming\\MiscAssignments\\Users.json";
        public static async Task LoadUsers()
        {
            using var streamReader = new StreamReader(FilePath);
            var jsonContent = await streamReader.ReadToEndAsync();
            _users = JsonSerializer.Deserialize<HashSet<User>>(jsonContent) ?? new();
        }
        public static async Task SaveUsers()
        {
            using var streamWriter = new StreamWriter(FilePath, false);
            var jsonContent = JsonSerializer.Serialize(_users, new JsonSerializerOptions { WriteIndented = true });
            await streamWriter.WriteAsync(jsonContent);
        }

        public static void AddUser(in User user) => _users.Add(user);
        public static void RemoveUser(in User user) => _users.Remove(user);
        public static bool EditUser(in User user, in User newUser)
        {
            if(!IsSameUser(user, newUser)) return false;
            RemoveUser(user);
            AddUser(newUser);
            return true;
        }

        public static User? SearchUser(Func<User, bool> predicate) => _users.FirstOrDefault(user => predicate(user));
        public static IEnumerable<User> GetUsers(byte quantity, byte offset) => _users.Skip(offset).Take(quantity);

        private static bool IsSameUser(in User user, User newUser, bool exact = false)
        {
            return SearchUser(user =>
            exact ?
            user.Name.Equals(newUser.Name, StringComparison.OrdinalIgnoreCase) &&
            user.Email.Equals(newUser.Name, StringComparison.OrdinalIgnoreCase) &&
            user.Name.Equals(newUser.Name, StringComparison.OrdinalIgnoreCase) :
            user.Name.Equals(newUser.Name, StringComparison.OrdinalIgnoreCase) ||
            user.Email.Equals(newUser.Name, StringComparison.OrdinalIgnoreCase) ||
            user.Name.Equals(newUser.Name, StringComparison.OrdinalIgnoreCase)
            ) != null;
        }
    }
}