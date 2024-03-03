namespace IntelliCrop.Domain.Interfaces;

public interface IProducerRepository : IGeneralRepository
{
    Task<Producer> GetProducerByIdAsyncEF(Guid? id);
    Task<Producer> GetProducerByIdAsyncSQL(Guid? id);
    Task<Producer> GetProducerByIdAsyncDAPPER(Guid? id);
}
