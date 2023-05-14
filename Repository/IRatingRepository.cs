using Entites;

namespace Services
{
    public interface IRatingRepository
    {
        public string _storeWebsiteContext { get; set; }

        Task Rate(Rating rating);
    }
}