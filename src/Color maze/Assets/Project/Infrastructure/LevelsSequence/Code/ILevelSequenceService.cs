using CapLib.Common;

namespace Infrastructure.LevelsSequence
{
	public interface ILevelSequenceService : IService
	{
		void LoadNextLevel();
	}
}