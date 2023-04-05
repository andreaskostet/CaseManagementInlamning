using System.Data.Entity;

namespace CaseManagementInlamning.DataAccess
{
    public class CaseManagementDBContext : DbContext
    {
        public CaseManagementDBContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Case> Cases { get; set; }
    }
}