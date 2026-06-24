using Pc27414u202319440.API.Services.Domain.Model.Aggregates;
using Pc27414u202319440.API.Services.Domain.Model.ValueObjects;
using Pc27414u202319440.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Pc27414u202319440.API.Shared.Infrastructure.Persistence.EFC.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Pc27414u202319440.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
/// Application database context for the Hertz schema.
/// </summary>
/// <remarks>Dhilsen Armil Mallqui Vilca</remarks>
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    /// <summary>
    /// Gets the rental orders set.
    /// </summary>
    public DbSet<RentalOrder> RentalOrders => Set<RentalOrder>();

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(builder);
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<RentalOrder>(entity =>
        {
            entity.HasKey(rentalOrder => rentalOrder.Id);
            entity.Property(rentalOrder => rentalOrder.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(rentalOrder => rentalOrder.Customer).HasMaxLength(90).IsRequired();
            entity.Property(rentalOrder => rentalOrder.VehiclesId).IsRequired();
            entity.Property(rentalOrder => rentalOrder.Plate).HasMaxLength(12);
            entity.Property(rentalOrder => rentalOrder.RequestedAt).IsRequired();
            entity.Property(rentalOrder => rentalOrder.Amount).IsRequired();

            entity.OwnsOne(rentalOrder => rentalOrder.Address, address =>
            {
                address.Property(value => value.Street).HasMaxLength(40).IsRequired();
                address.Property(value => value.City).HasMaxLength(40).IsRequired();
                address.Property(value => value.PostalCode).HasMaxLength(40).IsRequired();
            });

            entity.HasIndex(rentalOrder => new { rentalOrder.Customer, rentalOrder.VehiclesId })
                .IsUnique()
                .HasDatabaseName(RentalOrder.CustomerVehicleUniqueConstraint);
        });

        builder.UseSnakeCaseNamingConvention();
    }
}
