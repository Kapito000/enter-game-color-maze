using CapLib.Common;
using CapLib.StateMachine;

namespace CapLib.BaseStateMachines
{
	public interface IStateMediatorFactory<TState> : IFactory
		where TState : class, IState
	{
		IStateMediator<TState> Create(TState state);
	}
}