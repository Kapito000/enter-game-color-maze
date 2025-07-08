using CapLib.Id;

namespace Feature.FlipWall
{
	public interface IWallData
	{
		IId Id { get; }
		IWallTransitActor Actor { get; set; }
		IWallTrigger[] ContactTriggers { get; }
	}
}