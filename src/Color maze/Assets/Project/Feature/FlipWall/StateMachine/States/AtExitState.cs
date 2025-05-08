using CapLib.StateMachine;

namespace Feature.FlipWall.StateMachine.States
{
	public sealed class AtExitState : WallState, IWallState
	{
		public State State => State.AtExit;

		public void ActorEnterProcess(IWallTransitActor actor, IWallTrigger trigger)
		{
			if (IsOurWallTrigger(trigger) == false ||
			    trigger == Data.ContactTriggers[1])
				return;

			Data.ContactTriggers[0] = trigger;
			StateMachine.Enter(State.AtMiddle);
		}

		public void ActorExitProcess(IWallTransitActor actor, IWallTrigger trigger)
		{
			if (trigger == Data.ContactTriggers[1])
			{
				StateMachine.Enter(State.Outside);
				// Wall passed.
			}
		}
	}
}