
using Centraly.Api.Entities.Maintenance;
using Centraly.Api.Entities.Notifications;
using Centraly.Api.Entities.Wallets;
using System.Linq.Expressions;

namespace Centraly.Api.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
    IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{
    // Inventory
    public DbSet<Department> Departments => Set<Department>();     // Ã˜Â§Ã™â€žÃ˜Â£Ã™â€šÃ˜Â³Ã˜Â§Ã™â€¦ Ã˜Â§Ã™â€žÃ˜Â±Ã˜Â¦Ã™Å Ã˜Â³Ã™Å Ã˜Â© (Ã™â€¦Ã˜Â«Ã™â€žÃ˜Â§Ã™â€¹: Ã™â€¦Ã™Ë†Ã˜Â¨Ã˜Â§Ã™Å Ã™â€žÃ˜Â§Ã˜ÂªÃ˜Å’ Ã˜Â¥Ã™Æ’Ã˜Â³Ã˜Â³Ã™Ë†Ã˜Â§Ã˜Â±Ã˜Â§Ã˜Âª)
    public DbSet<Category> Categories => Set<Category>();          // Ã˜Â§Ã™â€žÃ˜ÂªÃ˜ÂµÃ™â€ Ã™Å Ã™ÂÃ˜Â§Ã˜Âª Ã˜Â§Ã™â€žÃ™ÂÃ˜Â±Ã˜Â¹Ã™Å Ã˜Â© Ã˜Â¬Ã™Ë†Ã™â€¡ Ã™Æ’Ã™â€ž Ã™â€šÃ˜Â³Ã™â€¦
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductBatch> ProductBatches => Set<ProductBatch>();
    public DbSet<ProductProperty> ProductProperties => Set<ProductProperty>();

    // Customers
    public DbSet<Customer> Customers => Set<Customer>();                        // Ã˜Â¨Ã™Å Ã˜Â§Ã™â€ Ã˜Â§Ã˜Âª Ã˜Â§Ã™â€žÃ˜Â¹Ã™â€¦Ã™â€žÃ˜Â§Ã˜Â¡ Ã™Ë†Ã™â€¦Ã˜Â¯Ã™Å Ã™Ë†Ã™â€ Ã™Å Ã˜ÂªÃ™â€¡Ã™â€¦ Ã˜Â§Ã™â€žÃ˜Â­Ã˜Â§Ã™â€žÃ™Å Ã˜Â©
    public DbSet<CustomerDebtPayment> CustomerDebtPayments => Set<CustomerDebtPayment>();  // Ã˜Â¯Ã™ÂÃ˜Â¹Ã˜Â§Ã˜Âª Ã˜ÂªÃ˜Â³Ã˜Â¯Ã™Å Ã˜Â¯ Ã™â€¦Ã˜Â¯Ã™Å Ã™Ë†Ã™â€ Ã™Å Ã˜Â© Ã˜Â§Ã™â€žÃ˜Â¹Ã™â€¦Ã™Å Ã™â€ž

    // Sales
    public DbSet<Invoice> Invoices => Set<Invoice>();               // Ã™ÂÃ™Ë†Ã˜Â§Ã˜ÂªÃ™Å Ã˜Â± Ã˜Â§Ã™â€žÃ˜Â¨Ã™Å Ã˜Â¹ (Ã˜Â¬Ã™â€¦Ã™â€žÃ˜Â©/Ã˜ÂªÃ˜Â¬Ã˜Â²Ã˜Â¦Ã˜Â©Ã˜Å’ Ã™Æ’Ã˜Â§Ã˜Â´/Ã˜Â¢Ã˜Â¬Ã™â€ž)
    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();   // Ã˜Â¨Ã™â€ Ã™Ë†Ã˜Â¯ Ã™Æ’Ã™â€ž Ã™ÂÃ˜Â§Ã˜ÂªÃ™Ë†Ã˜Â±Ã˜Â© Ã˜Â¨Ã™Å Ã˜Â¹ (Ã˜Â§Ã™â€žÃ™â€¦Ã™â€ Ã˜ÂªÃ˜Â¬Ã˜Å’ Ã˜Â§Ã™â€žÃ™Æ’Ã™â€¦Ã™Å Ã˜Â©Ã˜Å’ Ã˜Â§Ã™â€žÃ˜Â³Ã˜Â¹Ã˜Â± Ã™Ë†Ã™â€šÃ˜Âª Ã˜Â§Ã™â€žÃ˜Â¨Ã™Å Ã˜Â¹)

    // Returns
    public DbSet<ReturnRecord> Returns => Set<ReturnRecord>();      // Ã˜Â³Ã˜Â¬Ã™â€ž Ã™â€¦Ã˜Â±Ã˜ÂªÃ˜Â¬Ã˜Â¹Ã˜Â§Ã˜Âª Ã˜Â§Ã™â€žÃ˜Â¹Ã™â€¦Ã™â€žÃ˜Â§Ã˜Â¡ (Ã™â€¦Ã˜Â±Ã˜ÂªÃ˜Â¨Ã˜Â·Ã˜Â© Ã˜Â¨Ã™ÂÃ˜Â§Ã˜ÂªÃ™Ë†Ã˜Â±Ã˜Â© Ã˜Â¨Ã™Å Ã˜Â¹)
    public DbSet<ReturnItem> ReturnItems => Set<ReturnItem>();      // Ã˜Â¨Ã™â€ Ã™Ë†Ã˜Â¯ Ã™Æ’Ã™â€ž Ã˜Â¹Ã™â€¦Ã™â€žÃ™Å Ã˜Â© Ã˜Â¥Ã˜Â±Ã˜Â¬Ã˜Â§Ã˜Â¹ (Ã˜Â§Ã™â€žÃ™â€¦Ã™â€ Ã˜ÂªÃ˜Â¬ Ã™Ë†Ã˜Â§Ã™â€žÃ™Æ’Ã™â€¦Ã™Å Ã˜Â© Ã˜Â§Ã™â€žÃ™â€¦Ã˜Â±Ã˜ÂªÃ˜Â¬Ã˜Â¹Ã˜Â©)

    // Maintenance
    public DbSet<MaintenanceDevice> MaintenanceDevices => Set<MaintenanceDevice>();  // Ã˜Â£Ã˜Â¬Ã™â€¡Ã˜Â²Ã˜Â© Ã˜Â§Ã™â€žÃ˜ÂµÃ™Å Ã˜Â§Ã™â€ Ã˜Â© Ã˜Â§Ã™â€žÃ™Ë†Ã˜Â§Ã˜Â±Ã˜Â¯Ã˜Â© Ã™â€¦Ã™â€  Ã˜Â§Ã™â€žÃ˜Â¹Ã™â€¦Ã™â€žÃ˜Â§Ã˜Â¡ Ã™Ë†Ã˜Â­Ã˜Â§Ã™â€žÃ˜ÂªÃ™â€¡Ã˜Â§

    // Spare Parts
    public DbSet<MaintenanceProductItem> MaintenanceProductItems => Set<MaintenanceProductItem>();

    // Suppliers
    public DbSet<Supplier> Suppliers => Set<Supplier>();                             // Ã˜Â¨Ã™Å Ã˜Â§Ã™â€ Ã˜Â§Ã˜Âª Ã˜Â§Ã™â€žÃ™â€¦Ã™Ë†Ã˜Â±Ã˜Â¯Ã™Å Ã™â€  Ã™Ë†Ã™â€¦Ã˜Â¯Ã™Å Ã™Ë†Ã™â€ Ã™Å Ã˜ÂªÃ™â€¡Ã™â€¦
    public DbSet<PurchaseInvoice> PurchaseInvoices => Set<PurchaseInvoice>();         // Ã™ÂÃ™Ë†Ã˜Â§Ã˜ÂªÃ™Å Ã˜Â± Ã˜Â§Ã™â€žÃ˜ÂªÃ™Ë†Ã˜Â±Ã™Å Ã˜Â¯ (Ã˜Â´Ã˜Â±Ã˜Â§Ã˜Â¡ Ã˜Â¨Ã˜Â¶Ã˜Â§Ã˜Â¹Ã˜Â© Ã™â€¦Ã™â€  Ã™â€¦Ã™Ë†Ã˜Â±Ã˜Â¯)
    public DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems => Set<PurchaseInvoiceItem>();  // Ã˜Â¨Ã™â€ Ã™Ë†Ã˜Â¯ Ã™Æ’Ã™â€ž Ã™ÂÃ˜Â§Ã˜ÂªÃ™Ë†Ã˜Â±Ã˜Â© Ã˜ÂªÃ™Ë†Ã˜Â±Ã™Å Ã˜Â¯
    public DbSet<SupplierPayment> SupplierPayments => Set<SupplierPayment>();         // Ã˜Â¯Ã™ÂÃ˜Â¹Ã˜Â§Ã˜Âª Ã˜ÂªÃ˜Â³Ã˜Â¯Ã™Å Ã˜Â¯ Ã™â€¦Ã˜Â¯Ã™Å Ã™Ë†Ã™â€ Ã™Å Ã˜Â© Ã˜Â§Ã™â€žÃ™â€¦Ã™Ë†Ã˜Â±Ã˜Â¯
    public DbSet<SupplierReturn> SupplierReturns => Set<SupplierReturn>();            // Ã˜Â¥Ã˜Â±Ã˜Â¬Ã˜Â§Ã˜Â¹ Ã˜Â¨Ã˜Â¶Ã˜Â§Ã˜Â¹Ã˜Â© Ã™â€žÃ™â€žÃ™â€¦Ã™Ë†Ã˜Â±Ã˜Â¯ (Ã˜Â¹Ã˜Â·Ã™â€ž/Ã˜ÂªÃ˜ÂºÃ™Å Ã™Å Ã˜Â± Ã˜Â±Ã˜Â£Ã™Å )
    public DbSet<SupplierReturnItem> SupplierReturnItems => Set<SupplierReturnItem>();  // Ã˜Â¨Ã™â€ Ã™Ë†Ã˜Â¯ Ã™Æ’Ã™â€ž Ã˜Â¹Ã™â€¦Ã™â€žÃ™Å Ã˜Â© Ã˜Â¥Ã˜Â±Ã˜Â¬Ã˜Â§Ã˜Â¹ Ã™â€žÃ™â€žÃ™â€¦Ã™Ë†Ã˜Â±Ã˜Â¯

    // Drawer
    public DbSet<DrawerSession> DrawerSessions => Set<DrawerSession>();       // Ã˜Â¬Ã™â€žÃ˜Â³Ã˜Â§Ã˜Âª Ã™ÂÃ˜ÂªÃ˜Â­/Ã™â€šÃ™ÂÃ™â€ž Ã˜Â§Ã™â€žÃ˜Â¯Ã˜Â±Ã˜Â¬ (Ã˜Â±Ã˜ÂµÃ™Å Ã˜Â¯ Ã˜Â§Ã™ÂÃ˜ÂªÃ˜ÂªÃ˜Â§Ã˜Â­Ã™Å  Ã™Ë†Ã˜Â®Ã˜ÂªÃ˜Â§Ã™â€¦Ã™Å )
    public DbSet<DrawerTransaction> DrawerTransactions => Set<DrawerTransaction>();  // Ã™Æ’Ã™â€ž Ã˜Â­Ã˜Â±Ã™Æ’Ã˜Â© Ã™â€¦Ã˜Â§Ã™â€žÃ™Å Ã˜Â© Ã™ÂÃ˜Â¹Ã™â€žÃ™Å Ã˜Â© (Ã˜Â¥Ã™Å Ã˜Â±Ã˜Â§Ã˜Â¯/Ã˜ÂµÃ˜Â§Ã˜Â¯Ã˜Â±) Ã™ÂÃ™Å  Ã˜Â§Ã™â€žÃ˜Â¯Ã˜Â±Ã˜Â¬

    public DbSet<Safe> Safes => Set<Safe>();
    public DbSet<SafeTransaction> SafeTransactions => Set<SafeTransaction>();
    public DbSet<ExpenseCategory> ExpenseCategories => Set<ExpenseCategory>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<OwnerTransaction> OwnerTransactions => Set<OwnerTransaction>();
    public DbSet<TransactionSourcePolicy> TransactionSourcePolicies => Set<TransactionSourcePolicy>();

    // Wallets
    public DbSet<Wallet> Wallets => Set<Wallet>();
    public DbSet<WalletTransaction> WalletTransactions => Set<WalletTransaction>();
    public DbSet<WalletOperation> WalletOperations => Set<WalletOperation>();

    // Notifications
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>().HaveColumnType("decimal(18, 4)");
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);

        var allowedOpsComparer = new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<WalletOperationType>>(
            (c1, c2) => (c1 == null && c2 == null) || (c1 != null && c2 != null && c1.SequenceEqual(c2)),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList()
        );

        modelBuilder.Entity<Wallet>(b =>
        {
            b.Property(w => w.AllowedOperations)
                .HasConversion(
                    v => string.Join(",", v.Select(x => (int)x)),
                    v => string.IsNullOrEmpty(v)
                        ? new List<WalletOperationType> { WalletOperationType.CashIn, WalletOperationType.CashOut }
                        : v.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(s => (WalletOperationType)int.Parse(s))
                           .ToList()
                )
                .Metadata.SetValueComparer(allowedOpsComparer);

            b.Property(w => w.AllowedOperations)
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Safe>().HasData(
            new Safe
            {
                Id = DefaultSafe.MainSafeId,
                Name = DefaultSafe.MainSafeName,
                Balance = 0,
                IsMain = true,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(string)
                    && property.GetMaxLength() is null
                    && (property.Name == "Id" || property.Name.EndsWith("Id", StringComparison.Ordinal)))
                {
                    property.SetMaxLength(36);
                }
            }
        }
        var cascadeFKs = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade
                      && !fk.IsOwnership
                      && !fk.DeclaringEntityType.ClrType.Namespace!.Contains("Identity")
                      && !typeof(IdentityUser).IsAssignableFrom(fk.PrincipalEntityType.ClrType));

        foreach (var fk in cascadeFKs)
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
                var condition = Expression.Equal(property, Expression.Constant(false));
                var lambda = Expression.Lambda(condition, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
    }


    public override int SaveChanges()
    {
        ApplyAuditAndSoftDelete();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditAndSoftDelete();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditAndSoftDelete()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is BaseEntity baseEntity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        baseEntity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        baseEntity.UpdatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        baseEntity.IsDeleted = true;
                        baseEntity.DeletedAt = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}



