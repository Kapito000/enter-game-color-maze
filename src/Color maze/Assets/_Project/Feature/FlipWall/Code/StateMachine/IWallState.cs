using CapLib.StateMachine;

namespace Feature.FlipWall.StateMachine
{
	public interface IWallState : IState
	{
		public State State { get; }
		void ActorEnterProcess(IWallTransitActor actor, IWallTrigger trigger);
		void ActorExitProcess(IWallTransitActor actor, IWallTrigger trigger);
	}
}