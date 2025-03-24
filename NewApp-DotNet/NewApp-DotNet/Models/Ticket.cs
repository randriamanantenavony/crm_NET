public class Ticket
{
    public int TicketId { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public Users Manager { get; set; }
    public Users Employee { get; set; }
    public Customer Customer { get; set; }
    public DateTime? CreatedAt { get; set; }
}

public class Users
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Status { get; set; }
    public DateTime? HireDate { get; set; }
    public DateTime? CreatedAt { get; set; }
}

