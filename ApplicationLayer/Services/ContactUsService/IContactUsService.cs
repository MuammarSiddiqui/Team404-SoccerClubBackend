using DomainLayer.Models;

namespace ApplicationLayer.Services.ContactUsService
{
    public interface IContactUsService
    {
        Task<IEnumerable<ContactUs>> GetAll();
        Task<ContactUs> GetById(Guid id);
        Task<ContactUs> Add(ContactUs ContactUs);
        Task<ContactUs> Update(ContactUs ContactUs);
        Task<ContactUs> Remove(ContactUs ContactUs);
    }
}
