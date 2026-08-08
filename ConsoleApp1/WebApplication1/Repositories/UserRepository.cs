using ConferenceSystem.Models;

namespace ConferenceSystem.Repositories
{
    public class UserRepository
    {
        private static readonly List<User> _users = new();

        public IEnumerable<User> GetAll() => _users;

        public User? GetByUsername(string username) =>
            _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

        public void Add(User user)
        {
            user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
        }
    }
}