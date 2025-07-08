using CapLib.BaseStateMachines;
using UnityEngine.Assertions;

namespace Feature.FlipWall.StateMachine
{
	public sealed class WallStateMachine : BaseStateMachine<State, IWallState>,
		IWallStateMachine
	{
		public WallStateMachine(IMediatorContainer<State, IWallState> container)
			: base(container)
		{ }

		public void ActorEnterProcess(IWallTransitActor actor, IWallTrigger trigger)
		{
			Assert.IsNotNull(actor);
			Assert.IsNotNull(trigger);

			CurrentState.Value.ActorEnterProcess(actor, trigger);
		}

		public void ActorExitProcess(IWallTransitActor actor, IWallTrigger trigger)
		{
			Assert.IsNotNull(actor);
			Assert.IsNotNull(trigger);

			CurrentState.Value.ActorExitProcess(actor, trigger);
		}
	}
}