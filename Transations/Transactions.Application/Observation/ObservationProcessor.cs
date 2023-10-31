namespace Transactions.Application.Observation;

using Domain.Observation.Model;
using Domain.Observation.Repository;
using Domain.PotentialObservation.Model;
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

    public async Task ExecuteAsync()
    {
        var firstObservationId = Guid.NewGuid();
        var lastObservationId = Guid.NewGuid();

        //1. Save Observation
        var observation = new Observation
        {
                Id = firstObservationId,
                License = "ABC123",
                DeviceId = "1234567890"
        };
        await _observationRepository.Save(observation);

        //2. Save Potential Observation
        var firstObservation = await _observationRepository.GetAsync(firstObservationId);
        var potentialObservation = new PotentialObservation
        {
                Id = Guid.NewGuid(),
                Observations = new()
                {
                        firstObservation,
                        new()
                        {
                                Id = lastObservationId,
                                License = "ABC123",
                                DeviceId = "1234567890"
                        }
                }
        };
        await _potentialObservationRepository.Save(potentialObservation);
    }
}
