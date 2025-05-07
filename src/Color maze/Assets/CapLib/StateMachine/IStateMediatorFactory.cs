using CapLib.Common;

namespace CapLib.StateMachine
{
	public interface IStateMediatorFactory<TState> : IFactory
		where TState : class, IState
	{
		IStateMediator<TState> Create(TState state);
	}
}