using CapLib.GameStatus;

namespace Infrastructure.GameStatus.State
{
	public sealed class Start : BaseState, IState
	{
		public Start(IGameStateMachine gameStateMachine) : base(
			gameStateMachine)
		{ }

		public void Enter()
		{ }

		public void Exit()
		{ }
	}
}