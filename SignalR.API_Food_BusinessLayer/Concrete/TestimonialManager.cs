using SignalR.API_Food_BusinessLayer.Abstract;
using SignalR.API_Food_DataAccessLayer.Abstract;
using SignalR.API_Food_EntityLayer.Entities;

namespace SignalR.API_Food_BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void BAdd(Testimonial entity)
        {
            _testimonialDal.Add(entity);
        }

        public void BDelete(Testimonial entity)
        {
            _testimonialDal.Delete(entity);
        }

        public List<Testimonial> BGetAll() => _testimonialDal.GetAll();

        public Testimonial BGetById(int id) => _testimonialDal.GetById(id);

        public void BUpdate(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
