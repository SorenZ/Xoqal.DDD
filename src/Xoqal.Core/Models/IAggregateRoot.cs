namespace Xoqal.Core.Models
{
    /// <summary>
    /// Represent the top aggregate which speaks for the whole.
    /// It is important because it is the one that the rest of the world communicates with
    /// </summary>
    public interface IAggregateRoot : IAggregate
    { }

    /// <summary>
    /// Represent the top aggregate which speaks for the whole.
    /// It is important because it is the one that the rest of the world communicates with
    /// </summary>
    /// <typeparam name="TKey">Identity type of IAggregateRoot</typeparam>
    public interface IAggregateRoot<TKey> : IAggregate<TKey>
    { }
}
