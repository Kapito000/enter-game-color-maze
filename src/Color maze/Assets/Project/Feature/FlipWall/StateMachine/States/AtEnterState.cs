using CapLib.StateMachine;

namespace Feature.FlipWall.StateMachine.States
{
	public sealed class AtEnterState : WallState, IWallState
	{
		public State State => State.AtEnter;

		public void ActorEnterProcess(IWallTransitActor actor, IWallTrigger trigger)
		{
			if (IsOurWallTrigger(trigger) == false ||
			    trigger == Data.ContactTriggers[0])
				return;

			Data.ContactTriggers[1] = trigger;
			StateMachine.Enter(State.AtMiddle);
		}

		public void ActorExitProcess(IWallTransitActor actor, IWallTrigger trigger)
		{
			if (trigger == Data.ContactTriggers[0])
				StateMachine.Enter(State.Outside);
		}
	}
}