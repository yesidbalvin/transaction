namespace Transactions.Infrastructure.EntityFramework.Observation;

using Context;
using Domain.Observation.Model;
using Domain.Observation.Repository;

public class ObservationRepository : IObservationRepository
{
    private readonly TransactionsContext _context;

    public ObservationRepository(TransactionsContext context)
    {
        _context = context;
    }

    public async Task<Observation> GetAsync(Guid id)
    {
        return await _context.Observations.FindAsync(id);
    }

    public async Task Save(Observation observation)
    {
        _context.Observations.Add(observation);
        await _context.SaveChangesAsync();
    }
}
