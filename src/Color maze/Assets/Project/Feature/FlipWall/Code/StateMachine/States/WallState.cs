using Zenject;

namespace Feature.FlipWall.StateMachine.States
{
	public abstract class WallState
	{
		[Inject] IWallData _data;
		[Inject] IWallStateMachine _stateMachine;

		protected IWallData Data => _data;
		protected IWallStateMachine StateMachine => _stateMachine;

		protected bool IsOurWallTrigger(IWallTrigger trigger) =>
			trigger.WallId == Data.Id;
	}
}