using CapLib.Common;
using UniRx;

namespace Feature.FlipWall
{
	public interface IFlipWallSystem : ISystem
	{
		void Registry(IWall wall, WallKey key);
		void Flip();
		IReadOnlyReactiveProperty<WallKey> CurrentAvailableKey { get; }
	}
}