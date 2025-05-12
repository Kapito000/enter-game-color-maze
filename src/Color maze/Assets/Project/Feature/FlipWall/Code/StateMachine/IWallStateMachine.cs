using CapLib.StateMachine;

namespace Feature.FlipWall.StateMachine
{
	public interface IWallStateMachine : IStateMachine<State, IWallState>
	{
		void ActorEnterProcess(IWallTransitActor actor, IWallTrigger trigger);
		void ActorExitProcess(IWallTransitActor actor, IWallTrigger trigger);
	}
}