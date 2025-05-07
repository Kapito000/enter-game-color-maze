namespace CapLib.StateMachine
{
	public abstract class
		BaseStateMachine<TStateKey, TState> : IStateMachine<TStateKey, TState>
		where TState : class, IState
	{
		IStateMediator<TState> _currentState;
		
		readonly IMediatorContainer<TStateKey, TState> _states;

		protected TState CurrentState => _currentState.State;

		public BaseStateMachine(IMediatorContainer<TStateKey, TState> container)
		{
			_states = container;
		}

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
	}
}