namespace IntelliCrop.Domain.Interfaces;

public interface IGeneralRepository
{
    Task Create<T>(T entity) where T : class;
    Task Update<T>(T entity) where T : class;
    Task Delete<T>(T entity) where T : class;
}
