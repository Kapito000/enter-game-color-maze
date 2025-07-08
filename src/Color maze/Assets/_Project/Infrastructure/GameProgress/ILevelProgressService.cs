using CapLib.Common;

namespace Infrastructure.GameProgress
{
	public interface ILevelProgressService : IService
	{
		int CurrentLevel { get; set; }
		void Init();
	}
}