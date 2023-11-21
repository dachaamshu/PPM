namespace PPM.Model
{
public interface IEntityOperation<T>
{
    public void AddEntity(T entity);
    public List<T> ListAll();
    public List<T> ListById(int id);
    public void Delete(int id);
}
 
}