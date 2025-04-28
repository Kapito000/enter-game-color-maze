using CapLib.Common;

namespace CapLib.GameStatus
{
	public interface IGameStateMachine : IService
	{
		bool TryEnter<TState>() where TState : class, IState;
	}
}