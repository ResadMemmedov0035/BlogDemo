namespace BlogDemo.Domain.Base
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
    }
}
