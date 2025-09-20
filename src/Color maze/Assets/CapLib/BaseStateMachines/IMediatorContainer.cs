using CapLib.StateMachine;

namespace CapLib.BaseStateMachines
{
	public interface IMediatorContainer<TStateKey, TState>
		where TState : class, IState
	{
		bool TryAdd(TStateKey key, TState state);
		bool TryGet(TStateKey key, out IStateMediator<TState> state);
	}
}