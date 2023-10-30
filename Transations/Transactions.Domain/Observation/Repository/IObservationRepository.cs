namespace Transactions.Domain.Observation.Repository;

using Model;

public interface IObservationRepository
{
    Task<Observation> GetAsync(Guid id);
    Task Save(Observation observation);
}
