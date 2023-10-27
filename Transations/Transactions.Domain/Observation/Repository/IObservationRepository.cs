namespace Transactions.Domain.Observation.Repository;

using Model;

public interface IObservationRepository
{
    Task Save(Observation observation);
}
