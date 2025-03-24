using System;
using System.Collections.Generic;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
    public string Token { get; set; }
    public DateTime? HireDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<Role> Roles { get; set; }
    public UserProfile UserProfile { get; set; }
    public bool PasswordSet { get; set; }
    public bool InactiveUser { get; set; }
}