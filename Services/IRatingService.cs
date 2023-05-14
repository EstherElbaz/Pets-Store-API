using Entites;

namespace Services
{
    public interface IRatingService
    {
        Task Rate(Rating rating);

    }
}