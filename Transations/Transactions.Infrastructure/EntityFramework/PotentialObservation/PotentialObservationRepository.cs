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

    public Task Save(PotentialObservation potentialViolation)
    {
        throw new NotImplementedException();
    }
}
