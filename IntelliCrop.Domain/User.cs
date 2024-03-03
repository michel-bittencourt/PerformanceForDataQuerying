namespace IntelliCrop.Domain;

public sealed class User : EntityGuid
{
    public string Login { get; private set; }
    public string Password { get; private set; }
}
