using System;
using JapaneseLearning.Models;

namespace JapanseLearning.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public List<UserProgress>? Progress { get; set; }
    }
}