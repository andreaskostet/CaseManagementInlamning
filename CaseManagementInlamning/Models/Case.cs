using System;

namespace CaseManagementInlamning.Models
{
    public enum CaseStatus
    {
        New = 1,
        InProgress = 2,
        Closed = 3
    }

    public class Case
    {
        public int CaseId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public CaseStatus Status { get; set; }

        // Konstruktor
        public Case(int caseId, string customerFirstName, string customerLastName, string customerEmail, string customerPhone, string description, DateTime createdAt, CaseStatus status)
        {
            CaseId = caseId;
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            Description = description;
            CreatedAt = createdAt;
            Status = status;
        }
    }
}
