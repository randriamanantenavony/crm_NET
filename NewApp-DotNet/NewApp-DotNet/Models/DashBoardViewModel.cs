public class DashboardViewModel
{
    public TotalCount TotalCount { get; set; }
    public List<ClientStat> ClientStats { get; set; }

    // Ajout d'une nouvelle propriété pour les stats des tickets
    public List<TicketStatusCountViewModel> TicketStatusCounts { get; set; }

    
    public List<LeadStatusCountViewModel> LeadStatusCounts { get; set; }
}

// Nouveau modèle pour représenter un TicketStatusCount
public class TicketStatusCountViewModel
{
    public string Status { get; set; }
    public long TicketCount { get; set; }
}


public class LeadStatusCountViewModel
{
    public string Status { get; set; }
    public long LeadCount { get; set; }
}