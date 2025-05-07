namespace CapLib.StateMachine
{
	public class MediatorFactory<TState> : IStateMediatorFactory<TState>
		where TState : class, IState
	{
		public IStateMediator<TState> Create(TState state) =>
			new StateMediator<TState>(state);
	}
}