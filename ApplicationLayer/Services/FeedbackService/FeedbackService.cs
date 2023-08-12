using DomainLayer.Models;
using Infrastructure.Repositories.FeedbackRepository;


namespace ApplicationLayer.Services.FeedbackService
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackService(IFeedbackRepository repository)
        {
            _repository = repository;
        }
        public async Task<Feedback> Add(Feedback Feedback)
        {
            try
            {
                Feedback.Active = "Y";
                var res = await _repository.Add(Feedback);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Feedback>> GetAll()
        {
            try
            {
                var Feedback = await _repository.GetAll();
                return (from u in Feedback.Where(r => r.Active == "Y")
                        select u).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Feedback> GetById(Guid id)
        {
            Feedback res = await _repository.GetById(id);
            if (res == null || res.Active != "Y")
            {
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            return res;
        }

        public async Task<Feedback> Remove(Feedback Feedback)
        {
            try
            {
                Feedback.Active = "N";
                var res = await _repository.Update(Feedback);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Feedback> Update(Feedback Feedback)
        {
            try
            {
                Feedback.Active = "Y";
                var res = await _repository.Update(Feedback);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
