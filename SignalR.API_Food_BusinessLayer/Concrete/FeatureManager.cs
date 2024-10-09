using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void BAdd(Feature entity)
        {
            _featureDal.Add(entity);
        }

        public void BDelete(Feature entity)
        {
            _featureDal.Delete(entity);
        }

        public List<Feature> BGetAll()
        {
            return _featureDal.GetAll();
        }

        public Feature BGetById(int id)
        {
            return _featureDal.GetById(id);
        }

        public void BUpdate(Feature entity)
        {
            _featureDal.Update(entity);
        }
    }
}
