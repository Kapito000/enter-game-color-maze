using CapLib.GameStatus;

namespace Infrastructure.GameStatus.State
{
	public sealed class ExitGame : BaseState, IState
	{
		public ExitGame(IGameStateMachine gameStateMachine) : base(gameStateMachine)
		{ }

		public void Enter()
		{ }

		public void Exit()
		{ }
	}
}