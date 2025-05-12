using UniRx;

namespace CapLib.StateMachine
{
	public interface IStateMachine<TStateKey, TState> where TState : IState
	{
		IReadOnlyReactiveProperty<TState> CurrentState { get; }
		IReadOnlyReactiveProperty<TStateKey> CurrentStateKey { get; }
		bool TryAddState(TStateKey key, TState state);
		bool TryEnter(TStateKey key);
	}
}