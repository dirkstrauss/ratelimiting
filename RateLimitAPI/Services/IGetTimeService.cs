using System;
namespace RateLimitAPI.Services
{
	public interface IGetTimeService
	{
        TimeOnly currentTime();
	}
}