namespace MegaApi.DAL.DataRepositories;

public interface IRepository<TEntity>
{
    IEnumerable<TEntity> Get();
    TEntity? GetById(int id);
    void Insert(TEntity entity);
    void Remove(TEntity entity);
    void Remove(int id);
    void Update(TEntity entity);
    void SaveChanges();
}