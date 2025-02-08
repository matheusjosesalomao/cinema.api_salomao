using Domain.Adapters;
using Domain.Services;

namespace Application
{
    public class CheckInService : ICheckInService
    {
        private readonly ICheckInAdapter checkInAdapter;

        public CheckInService(ICheckInAdapter checkInAdapter)
        {
            ;
            this.checkInAdapter = checkInAdapter ?? throw new ArgumentNullException(nameof(checkInAdapter));
        }

        public async Task<bool> CheckInFilmeAsync(int movieId)
        {
            return await this.checkInAdapter.CheckInAsync(movieId);
        }
    }
}
