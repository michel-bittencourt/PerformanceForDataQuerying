using IntelliCrop.Application.Interfaces;
using IntelliCrop.Domain;
using IntelliCrop.Domain.Interfaces;

namespace IntelliCrop.Application.Services;

public class ProducerService : IProducerService
{
    #region Properties
    private readonly IProducerRepository _producerRepository;
    #endregion

    #region Constructor
    public ProducerService(IProducerRepository producerRepository)
    {
        _producerRepository = producerRepository;
    }
    #endregion

    #region CUD
    public async Task Add<T>(T entity) where T : class
    {
        await _producerRepository.Create(entity);
    }

    public async Task Update<T>(T entity) where T : class
    {
        await _producerRepository.Update(entity);
    }

    public async Task Delete(Guid? id)
    {
        var producerId = await _producerRepository.GetProducerByIdAsyncEF(id);
        await _producerRepository.Delete(producerId);
    }
    #endregion

    #region Reads
    public async Task<Producer> GetProducerByIdAsyncEF(Guid? id)
    {
        return await _producerRepository.GetProducerByIdAsyncEF(id);
    }

    public async Task<Producer> GetProducerByIdAsyncSQL(Guid? id)
    {
        return await _producerRepository.GetProducerByIdAsyncSQL(id);
    }

    public async Task<Producer> GetProducerByIdAsyncDAPPER(Guid? id)
    {
        return await _producerRepository.GetProducerByIdAsyncDAPPER(id);
    }
    #endregion
}
