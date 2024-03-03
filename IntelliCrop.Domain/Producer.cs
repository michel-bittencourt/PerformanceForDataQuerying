namespace IntelliCrop.Domain;

public sealed class Producer : EntityGuid
{
    #region Constructor
    public Producer(string firstName, string lastName, string? description, string phoneNumber, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        Description = description;
        PhoneNumber = phoneNumber;
        Address = address;
    }
    #endregion

    #region Entities
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? Description { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }
    #endregion
}
