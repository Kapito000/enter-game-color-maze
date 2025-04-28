using CapLib.Common;

namespace Infrastructure.Configuration
{
	public interface IGameConfig : IService
	{
		string FirstSceneName { get; }
	}
}