using CapLib.StateMachine;

namespace Feature.FlipWall.StateMachine.States
{
	public sealed class OutsideState : WallState, IWallState, IStateEnter
	{
		public State State => State.Outside;

		public void ActorEnterProcess(IWallTransitActor actor, IWallTrigger trigger)
		{
			if (IsOurWallTrigger(trigger) == false)
				return;

			Data.Actor = actor;
			Data.ContactTriggers[0] = trigger;
			StateMachine.Enter(State.AtEnter);
		}

		public void ActorExitProcess(IWallTransitActor actor, IWallTrigger trigger)
		{ }

		public void Enter()
		{
			Data.Actor = null;
			CleanContactTriggers();
		}

		void CleanContactTriggers()
		{
			for (var i = 0; i < Data.ContactTriggers.Length; i++)
				Data.ContactTriggers[i] = null;
		}
	}
}