using CapLib.Common;
using Eflatun.SceneReference;

namespace Infrastructure.LevelsSequence
{
	public interface ILevelsSequenceData : IStaticData
	{
		bool TryGetScene(int index, out SceneReference scene);
		int SceneCount { get; }
	}
}