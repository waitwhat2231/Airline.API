

namespace Airline.Application.Users
{
	public interface IUserContext
	{
		CurrentUser? GetCurrentUser();
	}
}
