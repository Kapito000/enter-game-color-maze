using CapLib.Common;

namespace Feature.FlipWall
{
	public interface IFlipWallSystem : ISystem
	{
		void Registry(IWall wall, WallKey key);
		void Flip();
	}
}