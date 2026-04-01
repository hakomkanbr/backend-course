namespace ECommerce.Repostories;

public class GenericRepostory<T> : IGenericRepostory<T>
{
    private readonly AppDbContext _context;

    public GenericRepostory(AppDbContext context)
    {
        _context = context;
    }
    public void Create(T entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int entityId)
    {
        throw new NotImplementedException();
    }

    public List<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetOne(int entityId)
    {
        throw new NotImplementedException();
    }

    public void Update(int entityId, T entity)
    {
        throw new NotImplementedException();
    }
}

