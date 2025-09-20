using CapLib.StateMachine;

namespace Feature.FlipWall.StateMachine.States
{
	public sealed class AtMiddleState : WallState, IWallState
	{
		public State State => State.AtMiddle;

		public void ActorEnterProcess(IWallTransitActor actor, IWallTrigger trigger)
		{ }

		public void ActorExitProcess(IWallTransitActor actor, IWallTrigger trigger)
		{
			if (trigger == Data.ContactTriggers[0])
			{
				Data.ContactTriggers[0] = null;
				StateMachine.Enter(State.AtExit);
			}

			if (trigger == Data.ContactTriggers[1])
			{
				Data.ContactTriggers[1] = null;
				StateMachine.Enter(State.AtEnter);
			}
		}
	}
}