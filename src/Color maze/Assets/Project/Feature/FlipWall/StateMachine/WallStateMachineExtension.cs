using CapLib.StateMachine;

namespace Feature.FlipWall.StateMachine
{
	public static class WallStateMachineExtension
	{
		public static IWallStateMachine AddState(
			this IWallStateMachine stateMachine,
			IWallState state)
		{
			stateMachine.AddState(state.State, state);
			return stateMachine;
		}
	}
}