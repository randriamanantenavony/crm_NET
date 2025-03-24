public class Lead
{
    public int LeadId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string Phone { get; set; }
    public int? MeetingId { get; set; }
    public string GoogleDrive { get; set; }
    public string GoogleDriveFolderId { get; set; }
    public User Manager { get; set; } // Assuming Manager is of type User
    public User Employee { get; set; } // Assuming Employee is of type User
    public Customer Customer { get; set; } // Assuming Customer is another class
    public DateTime CreatedAt { get; set; }
}
