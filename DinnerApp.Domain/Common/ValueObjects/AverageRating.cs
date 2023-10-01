namespace DinnerApp.Domain.Common.ValueObjects;

public record AverageRating
{
    public double Value { get; private set; }
    public int NumRating { get; private set; }

    private AverageRating(double value, int numRating)
    {
        Value = value;
        NumRating = numRating;
    }
    public static AverageRating Create(double rating, int numRating)
    {
        return new(rating, numRating);
    }

    public void AddNewRating(Rating rating)
    {
        Value = ((Value * NumRating) + rating.Value) / ++NumRating;
    }
    public void RemoveRating(Rating rating)
    {
        Value = ((Value * NumRating) + rating.Value) / --NumRating;
    }
}
