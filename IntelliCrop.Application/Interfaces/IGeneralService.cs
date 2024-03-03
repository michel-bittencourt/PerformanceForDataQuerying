namespace IntelliCrop.Application.Interfaces;

public interface IGeneralService
{
    Task Add<T>(T entity) where T : class;
    Task Update<T>(T entity) where T : class;
    Task Delete(Guid? id);
}
