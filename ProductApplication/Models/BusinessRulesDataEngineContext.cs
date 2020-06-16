using LinqToDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessRuleApplication.Models
{
    public class BusinessRulesDataEngineContext : DbContext

    {
        //public BusinessRulesDataEngineContext() : base() { Database.EnsureCreated(); }

        public BusinessRulesDataEngineContext() : base()
        {
            try
            {
                //string defaultConnection = "server=localhost;Initial Catalog=BusinessRules;User ID=sa;Password=admin;Integrated Security=false;";
              
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BusinessRulesDataEngineContext(DbContextOptions<BusinessRulesDataEngineContext> options)
                 : base(options)
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        //private readonly string _connectionString;
        //public BusinessRulesDataEngineContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}
        public DbSet<Modules> Module { get; set; }
        public DbSet<PaymentOptions> PaymentOption { get; set; }
        public DbSet<BusinessRules> BusinessRule { get; set; }
        public DbSet<MemberShip> MemberShip { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<SlipDeatils> SlipDeatil { get; set; }

        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentCommission> AgentCommission { get; set; }
        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BusinessRules>(entity =>
        //    {
        //        entity.HasKey(e => e.ProductPaymentRuleId);

        //        entity.HasIndex(e => e.ModuleId)
        //            .HasName("IX_BusinessRule_ProductIdModuleId");

        //        entity.HasOne(d => d.Module)
        //            .WithMany(p => p.BusinessRule)
        //            .HasForeignKey(d => d.ModuleId)
        //            .HasConstraintName("FK_BusinessRule_Module_ProductIdModuleId");

        //        entity.HasOne(d => d.Payment)
        //            .WithMany(p => p.BusinessRule)
        //            .HasForeignKey(d => d.PaymentId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_BusinessRule_PaymentOption");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string connectionUrl = Environment.GetEnvironmentVariable("EmployeeContexturl");
                //var KeyVaultUrl = connectionUrl; //"https://lexkeyvault1.vault.azure.net/secrets/BloggingContext/b0822325f48b4c2cbc7997af937052e9";
                //AzureServiceTokenProvider azureServiceTokenProvider = new AzureServiceTokenProvider();
                //KeyVaultClient keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
                //var defaultConnection = keyVaultClient.GetSecretAsync(KeyVaultUrl).Result.Value;
                //  _loggerFactory = new LoggerFactory();
                //  var logger = _loggerFactory.CreateLogger("defaultConnection");
                //logger.LogInformation("defaultConnection");
                string defaultConnection = "server=localhost;Initial Catalog=BusinessRules1;User ID=sa;Password=admin;Integrated Security=false;";
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(defaultConnection);

            }
        }
    }
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BusinessRulesDataEngineContext>
    //{
    //    public BusinessRulesDataEngineContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<BusinessRulesDataEngineContext>();
    //        optionsBuilder.UseSqlServer(@"Server=localhost;Database=BusinessRules;User ID=sa;Password=admin;Trusted_Connection=False;");

    //        return new BusinessRulesDataEngineContext(optionsBuilder.Options);
    //    }
    //}
}