using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Concrete;
using SignalR.API_Food_DataAccessLayer.Repositories;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_DataAccessLayer.EntityFramework
{
    public class EfFeatureDal : GenericRepository<Feature>, IFeatureDal
    {
        public EfFeatureDal(SignalRContext context) : base(context)
        {
        }
    }
}
