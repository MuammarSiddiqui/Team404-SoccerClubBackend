using DomainLayer.Models;
using Infrastructure.Repositories.ContactUsRepository;


namespace ApplicationLayer.Services.ContactUsService
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _repository;

        public ContactUsService(IContactUsRepository repository)
        {
            _repository = repository;
        }
        public async Task<ContactUs> Add(ContactUs ContactUs)
        {
            try
            {
                ContactUs.Active = "Y";
                var res = await _repository.Add(ContactUs);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ContactUs>> GetAll()
        {
            try
            {
                var ContactUs = await _repository.GetAll();
                return (from u in ContactUs.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ContactUs> GetById(Guid id)
        {
            ContactUs res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<ContactUs> Remove(ContactUs ContactUs)
        {
            try
            {
                ContactUs.Active = "N";
                var res = await _repository.Update(ContactUs);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ContactUs> Update(ContactUs ContactUs)
        {
            try
            {
                ContactUs.Active = "Y";
                var res = await _repository.Update(ContactUs);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
