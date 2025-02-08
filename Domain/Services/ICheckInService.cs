namespace Domain.Services
{
    public interface ICheckInService
    {
        Task<bool> CheckInFilmeAsync(int movieId);
    }
}
