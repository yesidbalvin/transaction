namespace Transactions.Infrastructure.Context;

using Domain.Observation.Model;
using Domain.PotentialObservation.Model;
using Microsoft.EntityFrameworkCore;

public class TransactionsContext : DbContext
{
    public TransactionsContext(DbContextOptions<TransactionsContext> options) : base(options)
    {
    }

    public DbSet<Observation> Observations { get; set; }
    public DbSet<PotentialObservation> PotentialObservations { get; set; }
}
