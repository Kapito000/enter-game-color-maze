using CapLib.GameStatus;

namespace Infrastructure.GameStatus.State
{
	public abstract class BaseState
	{
		protected IGameStateMachine GameStateMachine { get; }

		protected BaseState(IGameStateMachine gameStateMachine)
		{
			GameStateMachine = gameStateMachine;
		}
	}
}