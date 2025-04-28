using CapLib.GameStatus;
using Game.Input;
using Zenject;

namespace Infrastructure.GameStatus.State
{
	public sealed class Loop : IState
	{
		[Inject] IMovementInput	_movementInput;
		
		public void Enter()
		{
			_movementInput.Enable();
		}

		public void Exit()
		{
			_movementInput.Disable();
		}
	}
}