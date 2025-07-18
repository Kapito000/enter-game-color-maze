using CapLib.GameStatus;
using Feature.CameraModuleInput;
using Feature.MovementInput;
using Feature.ServicesInput;
using Zenject;

namespace Infrastructure.GameStatus.State
{
	public sealed class Loop : IState
	{
		[Inject] ICameraInput _cameraInput;
		[Inject] IMovementInput _movementInput;
		[Inject] IServicesInput _servicesInput;

		public void Enter()
		{
			_cameraInput.Enable();
			_servicesInput.Enable();
			_movementInput.Enable();
		}

		public void Exit()
		{
			_cameraInput.Disable();
			_servicesInput.Disable();
			_movementInput.Disable();
		}
	}
}