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

    public Task Save(Observation observation)
    {
        throw new NotImplementedException();
    }
}
