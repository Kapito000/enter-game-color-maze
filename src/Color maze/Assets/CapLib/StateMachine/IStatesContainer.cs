namespace CapLib.StateMachine
{
	public interface IStatesContainer<in TStateKey, TState> where TState : IState
	{
		bool TryGet(TStateKey key, out TState state);

		bool TryAdd(TStateKey key, TState state);
	}
}