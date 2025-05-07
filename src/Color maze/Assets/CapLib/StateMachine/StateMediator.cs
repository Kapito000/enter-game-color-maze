using UnityEngine.Assertions;

namespace CapLib.StateMachine
{
	public class StateMediator<TState> : IStateMediator<TState>
		where TState : class, IState
	{
		readonly IStateEnter _enter;
		readonly IStateExit _exit;

		public TState State { get; }

		public StateMediator(TState state)
		{
			Assert.IsNotNull(state);
			State = state;
			_enter = state as IStateEnter;
			_exit = state as IStateExit;
		}

		public void Enter() =>
			_enter?.Enter();

		public void Exit() =>
			_exit?.Exit();
	}
}