namespace Transactions.Domain.PotentialObservation.Repository;

using Model;

public interface IPotentialObservationRepository
{
    Task Save(PotentialObservation potentialViolation);
}
