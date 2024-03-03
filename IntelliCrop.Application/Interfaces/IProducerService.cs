using IntelliCrop.Domain;

namespace IntelliCrop.Application.Interfaces;

public interface IProducerService : IGeneralService
{
    Task<Producer> GetProducerByIdAsyncEF(Guid? id);
    Task<Producer> GetProducerByIdAsyncSQL(Guid? id);
    Task<Producer> GetProducerByIdAsyncDAPPER(Guid? id);
}
