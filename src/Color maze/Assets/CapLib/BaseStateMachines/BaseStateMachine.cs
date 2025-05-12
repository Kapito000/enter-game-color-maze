using CapLib.StateMachine;
using UniRx;
using UnityEngine.Assertions;

namespace CapLib.BaseStateMachines
{
	public abstract class
		BaseStateMachine<TStateKey, TState> : IStateMachine<TStateKey, TState>
		where TState : class, IState
	{
		IStateMediator<TState> _currentState;

		ReactiveProperty<TState> _currentStateProperty = new();
		ReactiveProperty<TStateKey> _currentStateKey = new();

		readonly IMediatorContainer<TStateKey, TState> _states;

		public IReadOnlyReactiveProperty<TState> CurrentState =>
			_currentStateProperty;
		public IReadOnlyReactiveProperty<TStateKey> CurrentStateKey =>
			_currentStateKey;

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
			SetCurrentState(key, nextState);
			Assert.IsNotNull(_currentState);
			_currentState.Enter();
			return true;
		}

		void SetCurrentState(TStateKey key, IStateMediator<TState> nextState)
		{
			_currentState = nextState;

			_currentStateKey.Value = key;
			_currentStateProperty.Value = nextState.State;
		}
	}
}