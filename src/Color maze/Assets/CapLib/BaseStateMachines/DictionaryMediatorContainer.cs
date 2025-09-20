using System.Collections.Generic;
using CapLib.StateMachine;

namespace CapLib.BaseStateMachines
{
	public class DictionaryMediatorContainer<TStateKey, TState>
		: IMediatorContainer<TStateKey, TState>
		where TState : class, IState
	{
		readonly IStateMediatorFactory<TState> _mediatorFactory;
		readonly Dictionary<TStateKey, IStateMediator<TState>> _states = new();

		public DictionaryMediatorContainer(
			IStateMediatorFactory<TState> mediatorFactory)
		{
			_mediatorFactory = mediatorFactory;
		}

		public bool TryAdd(TStateKey key, TState state)
		{
			var mediator = _mediatorFactory.Create(state);
			return _states.TryAdd(key, mediator);
		}

		public bool TryGet(TStateKey key, out IStateMediator<TState> mediator) =>
			_states.TryGetValue(key, out mediator);
	}
}