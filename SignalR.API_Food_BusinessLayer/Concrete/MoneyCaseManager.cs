using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
	public class MoneyCaseManager : IMoneyCaseService
	{
		private readonly IMoneyCaseDal _moneyCaseDal;

		public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
		{
			_moneyCaseDal = moneyCaseDal;
		}

		public void BAdd(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public void BDelete(MoneyCase entity)
		{
			throw new NotImplementedException();
		}

		public List<MoneyCase> BGetAll()
		{
			throw new NotImplementedException();
		}

		public MoneyCase BGetById(int id)
		{
			throw new NotImplementedException();
		}

		public decimal BTotalMoneyCaseAmount() => _moneyCaseDal.TotalMoneyCaseAmount();

		public void BUpdate(MoneyCase entity)
		{
			throw new NotImplementedException();
		}
	}
}
