namespace SignalR.API_Food_BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void BAdd(T entity);
        void BDelete(T entity);
        void BUpdate(T entity);
        T BGetById(int id);
        List<T> BGetAll();
    }
}
