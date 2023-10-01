namespace DinnerApp.Domain.Abstracts;

public abstract class Entity<TId> where TId : notnull
{
    public TId Id { get; private set; }

    public Entity(TId id)
    {
        Id = id;
    }
}
