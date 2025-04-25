namespace CapLib.GameStatus
{
	public interface IGameStateMachine
	{
		bool TryEnter<TState>() where TState : class, IState;
		bool TryGetState<TState>(out TState state) where TState : class, IState;
	}
}