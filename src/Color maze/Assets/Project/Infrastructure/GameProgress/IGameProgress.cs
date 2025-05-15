using CapLib.Common;

namespace Infrastructure.GameProgress
{
	public interface IGameProgress : IService
	{
		int CurrentLevel { get; }
	}
}