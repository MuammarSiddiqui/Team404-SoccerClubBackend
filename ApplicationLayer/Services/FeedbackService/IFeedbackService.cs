using DomainLayer.Models;

namespace ApplicationLayer.Services.FeedbackService
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAll();
        Task<Feedback> GetById(Guid id);
        Task<Feedback> Add(Feedback Feedback);
        Task<Feedback> Update(Feedback Feedback);
        Task<Feedback> Remove(Feedback Feedback);
    }
}
