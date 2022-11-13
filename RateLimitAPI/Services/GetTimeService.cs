using System;
namespace RateLimitAPI.Services
{
	public class GetTimeService : IGetTimeService
	{
		public GetTimeService()
		{
		}

        public TimeOnly currentTime()
        {
            return TimeOnly.FromDateTime(DateTime.Now);
        }
    }
}