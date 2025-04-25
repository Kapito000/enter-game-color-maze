using CapLib.Common;

namespace CapLib.GameStatus
{
	public sealed class GameStateMachine : IGameStateMachine
	{
		IState _activeState;
		readonly TypeLocator<IState> _states = new();

		public GameStateMachine(IState[] states)
		{
			_states.Register(states);	
		}

		public bool TryEnter<TState>() where TState : class, IState
		{
			if (TryGetState<TState>(out var state) == false)
				return false;

			_activeState?.Exit();
			_activeState = state;
			state.Enter();
			return true;
		}

		public bool TryGetState<TState>(out TState state)
			where TState : class, IState
		{
			var result = _states.TryGet<TState>(out var obj);
			state = result ? obj as TState : null;
			return result;
		}
	}
}