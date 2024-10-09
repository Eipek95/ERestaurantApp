using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
	public class SliderManager : ISliderService
	{
		private readonly ISliderDal _sliderDal;

		public SliderManager(ISliderDal sliderDal)
		{
			_sliderDal = sliderDal;
		}

		public void BAdd(Slider entity)
		{
			_sliderDal.Add(entity);
		}

		public void BDelete(Slider entity)
		{
			_sliderDal.Delete(entity);
		}

		public List<Slider> BGetAll() => _sliderDal.GetAll();
		public Slider BGetById(int id)
		{
			return _sliderDal.GetById(id);
		}

		public void BUpdate(Slider entity)
		{
			_sliderDal.Update(entity);
		}
	}
}
