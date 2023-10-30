namespace Transactions.Infrastructure.EntityFramework.PotentialObservation;

using Context;
using Domain.PotentialObservation.Model;
using Domain.PotentialObservation.Repository;

public class PotentialObservationRepository : IPotentialObservationRepository
{
    private readonly TransactionsContext _context;

    public PotentialObservationRepository(TransactionsContext context)
    {
        _context = context;
    }

    public async Task Save(PotentialObservation potentialViolation)
    {
        _context.PotentialObservations.Add(potentialViolation);
        await _context.SaveChangesAsync();
    }
}
