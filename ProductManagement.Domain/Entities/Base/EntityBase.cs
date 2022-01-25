namespace ProductManagement.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
