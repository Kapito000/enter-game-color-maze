using CapLib.GameStatus;
using Feature.CameraModuleInput;
using Feature.MovementInput;
using Zenject;

namespace Infrastructure.GameStatus.State
{
	public sealed class Loop : IState
	{
		[Inject] ICameraInput _cameraInput;
		[Inject] IMovementInput _movementInput;

		public void Enter()
		{
			_cameraInput.Enable();
			_movementInput.Enable();
		}

		public void Exit()
		{
			_cameraInput.Disable();
			_movementInput.Disable();
		}
	}
}