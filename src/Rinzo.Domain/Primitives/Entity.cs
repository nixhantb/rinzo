namespace Rinzo.Domain.Primitives
{
    /// <summary>
    /// Represents the base class for all domain entities.
    /// Provides identity-based equality by overriding Equals and equality operators.
    /// </summary>
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private init; }

        #region Equality Logic

        public static bool operator == (Entity? first, Entity? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        public static bool operator !=(Entity? first, Entity? second)
        {
            return !(first == second);
        }

        public bool Equals(Entity? other)
        {
            if (other is null)
                return false;

            if (other.GetType() != GetType())
                return false;

            return other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}
