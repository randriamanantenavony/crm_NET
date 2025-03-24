public class Roles
{
    public int id { get; set; }
    public string name { get; set; }
}

public class CustomerUser
{
    public int id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string status { get; set; }
    public string token { get; set; }
    public DateTime? hireDate { get; set; }         // nullable
    public DateTime? createdAt { get; set; }        // nullable
    public DateTime? updatedAt { get; set; }        // nullable
    public object oauthUser { get; set; }           // ou un type si connu
    public List<Roles> roles { get; set; }
    public object userProfile { get; set; }         // ou un type si connu
    public bool inactiveUser { get; set; }
    public bool passwordSet { get; set; }
}

public class Customer
{
    public int customerId { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string position { get; set; }
    public string phone { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string country { get; set; }
    public string description { get; set; }
    public string twitter { get; set; }
    public string facebook { get; set; }
    public string youtube { get; set; }
    public CustomerUser user { get; set; }
    public DateTime? createdAt { get; set; }        // nullable au cas où
}
