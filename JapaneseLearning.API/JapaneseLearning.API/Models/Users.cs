using System;
using JapaneseLearning.Models;

namespace JapaneseLearning.Models
{
    public class Users
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public List<UserProgress>? Progress { get; set; }

        public string NormalizedUsername => Username.ToUpper();
        public string NormalizedEmail => Email.ToUpper();
    }
}