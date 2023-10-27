namespace Transactions.Application.Observation;

using Domain.Observation.Repository;
using Domain.PotentialObservation.Repository;

public class ObservationProcessor : IObservationProcessor
{
    private readonly IObservationRepository _observationRepository;
    private readonly IPotentialObservationRepository _potentialObservationRepository;

    public ObservationProcessor(
            IObservationRepository observationRepository,
            IPotentialObservationRepository potentialObservationRepository)
    {
        _observationRepository = observationRepository;
        _potentialObservationRepository = potentialObservationRepository;
    }

    public Task ExecuteAsync()
    {
        throw new NotImplementedException();
    }
}
