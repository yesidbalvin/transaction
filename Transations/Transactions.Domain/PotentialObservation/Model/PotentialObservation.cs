namespace Transactions.Domain.PotentialObservation.Model;

using Observation.Model;

public class PotentialObservation
{
    public Guid Id { get; set; }
    public List<Observation> Observations { get; set; }
}
