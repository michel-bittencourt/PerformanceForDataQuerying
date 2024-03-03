namespace IntelliCrop.Domain;

public abstract class Entity
{
    public DateTime RegistrationDate { get; set; } = new DateTime();
    public bool Active { get; private set; } = true;
}

public abstract class EntityId : Entity
{
    public int Id { get; protected set; }
}

public abstract class EntityGuid : Entity
{
    public Guid Id { get; protected set; }
    public EntityGuid()
    {
        Id = Guid.NewGuid();
    }
}
