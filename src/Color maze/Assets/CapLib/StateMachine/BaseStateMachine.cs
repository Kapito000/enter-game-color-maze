namespace CapLib.StateMachine
{
	public abstract class
		BaseStateMachine<TStateKey, TState> : IStateMachine<TStateKey, TState>
		where TState : IState
	{
		TState _currentState;
		IStatesContainer<TStateKey, TState> _states;

		public bool TryAddState(TStateKey key, TState state) =>
			_states.TryAdd(key, state);

		public bool TryEnter(TStateKey key)
		{
			if (_states.TryGet(key, out var nextState) == false)
				return false;

			_currentState?.Exit();
			_currentState = nextState;
			_currentState.Enter();
			return true;
		}

		protected void SetStatesContainer(
			IStatesContainer<TStateKey, TState> statesContainer)
		{
			_states = statesContainer;
		}
	}
}