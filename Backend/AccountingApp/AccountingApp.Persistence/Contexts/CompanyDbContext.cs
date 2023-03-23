using AccountingApp.Domain.Abstractions;
using AccountingApp.Domain.AppEntities;
using AccountingApp.Domain.CompanyEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AccountingApp.Persistence.Contexts
{
    public class CompanyDbContext : DbContext
    {
        private string ConnectionString = "";

        public CompanyDbContext(Company company = null)
        {
            if (company != null)
            {
                if (company.UserId == "")
                    ConnectionString = $"Data Source={company.ServerName};Initial Catalog={company.DatabaseName};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                else
                    ConnectionString = $"Data Source={company.ServerName};Initial Catalog={company.DatabaseName};User Id= {company.UserId}; Password={company.Password};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
            else
            {
                //ConnectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CompanyTestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                ConnectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MainAccountingDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    //entry.Property(p => p.Id).CurrentValue = Guid.NewGuid().ToString();
                    entry.Property(p => p.CreatedDate).CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                    entry.Property(p => p.UpdatedDate).CurrentValue = DateTime.Now;
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            public CompanyDbContext CreateDbContext(string[] args)
            {
                return new CompanyDbContext();
            }
        }
        public DbSet<UniformChartOfAccount> UniformChartOfAccounts { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

    }
}
