using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
	public class MessageManager : IMessageService
	{
		private readonly IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public void BAdd(Message entity) => _messageDal.Add(entity);

		public void BDelete(Message entity) => _messageDal.Delete(entity);
		public List<Message> BGetAll() => _messageDal.GetAll();
		public Message BGetById(int id) => _messageDal.GetById(id);

		public void BUpdate(Message entity) => _messageDal.Update(entity);
	}
}
