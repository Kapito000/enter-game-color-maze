using CapLib.GameStatus;

namespace Infrastructure.GameStatus.State
{
	public sealed class Loop : BaseState, IState
	{
		public Loop(IGameStateMachine gameStateMachine) :
			base(gameStateMachine)
		{ }
		
		public void Enter()
		{ }

		public void Exit()
		{ }
	}
}