using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            _menuTableDal = menuTableDal;
        }

        public void BAdd(MenuTable entity) => _menuTableDal.Add(entity);

        public void BDelete(MenuTable entity) => _menuTableDal.Delete(entity);

        public List<MenuTable> BGetAll() => _menuTableDal.GetAll();

        public MenuTable BGetById(int id) => _menuTableDal.GetById(id);

        public int BMenuTableCount() => _menuTableDal.MenuTableCount();

        public void BUpdate(MenuTable entity) => _menuTableDal.Update(entity);
    }
}
