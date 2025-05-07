using System;

namespace CapLib.StateMachine
{
	public interface IStateMachine<in TStateKey, TState> where TState : IState
	{
		bool TryAddState(TStateKey key, TState state);
		bool TryEnter(TStateKey key);
	}
}