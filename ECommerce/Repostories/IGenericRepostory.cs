using ECommerce.Enitites;
using ECommerce.Enitites.Products;

namespace ECommerce.Repostories;

public interface IGenericRepostory<T>
{
    void Create(T entity);
    List<T> GetAll();
    T GetOne(int entityId);
    Task Delete(int entityId);
    void Update(int entityId, T entity);
}

