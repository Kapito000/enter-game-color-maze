namespace CapLib.StateMachine
{
	public interface IStatesContainer<in TStateKey, TState>
		where TState : IState
	{
		bool TryAdd(TStateKey key, TState state);
		bool TryGet(TStateKey key, out TState state);
	}
}