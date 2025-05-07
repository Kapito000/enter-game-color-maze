namespace CapLib.StateMachine
{
	public interface IStateMediator<out TState> : IFullState
		where TState : class, IState
	{
		public TState State { get; }
	}
}