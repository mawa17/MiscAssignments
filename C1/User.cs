using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace C1
{
    public sealed record User(string Name, [Phone] string Number, [EmailAddress(ErrorMessage = "Incorrect Phone Number")] string Email);

    public static class UserValidator
    {
        public static List<ValidationResult>? Validate(this User user)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(user);

            bool isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            return isValid ? null : validationResults;
        }

        public static bool IsValid(this User user) => Validate(user) is null;
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
        public static bool EditUser(in User user, in User newUser, bool exact = false)
        {
            var usr = SearchUser(user, exact);
            if (usr is null) return false;
            RemoveUser(usr);
            AddUser(newUser);
            return true;
        }
        public static IEnumerable<User> GetUsers(this IEnumerable<User> users, byte quantity, byte offset) => users.Skip(offset).Take(quantity);
        public static IEnumerable<User> SortUsers(this IEnumerable<User> users, Func<User, User> func) => users.OrderBy(func);
        private static User? SearchUser(User user, bool exact = false)
        {
            return _users.Where(usr =>
            exact ?
            usr.Name.Equals(user.Name, StringComparison.OrdinalIgnoreCase) &&
            usr.Name.Equals(user.Email, StringComparison.OrdinalIgnoreCase) &&
            usr.Number.Equals(user.Number, StringComparison.OrdinalIgnoreCase) :
            usr.Name.Equals(user.Name, StringComparison.OrdinalIgnoreCase) ||
            usr.Name.Equals(user.Email, StringComparison.OrdinalIgnoreCase) ||
            usr.Name.Equals(user.Number, StringComparison.OrdinalIgnoreCase)).First() ?? null;
        }
        private static IEnumerable<User?> SearchUsers(bool exact = false, params User[] users) => 
            users.Select(user => SearchUser(user, exact)).Where(result => result != null); 
    }
}