using System;
using CapLib.Id;

namespace Feature.FlipWall
{
	public interface IWallTrigger
	{
		public IId WallId { get; }
		public IObservable<IWallTransitActor> ActorEntered { get; }
		public IObservable<IWallTransitActor> ActorExited { get; }
	}
}