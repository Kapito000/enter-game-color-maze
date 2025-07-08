using System;
using Game.Input;
using UniRx;
using UnityEngine.InputSystem;

namespace Feature.CameraModuleInput
{
	public sealed class CameraInput : ICameraInput
	{
		CompositeDisposable _disposables = new();

		readonly InputActions _actions;
		readonly Subject<Unit> _switchCameraModePerformed = new();

		public IObservable<Unit> SwitchCameraModePerformed =>
			_switchCameraModePerformed;

		public CameraInput(InputActions actions)
		{
			_actions = actions;
			SwitchCameraModeSubscribe();
		}

		public void Enable()
		{
			_actions.Camera.Enable();
		}

		public void Disable()
		{
			_actions.Camera.Disable();
		}

		public void Dispose()
		{
			_disposables.Dispose();
			_switchCameraModePerformed.OnCompleted();
			_switchCameraModePerformed.Dispose();
		}

		void SwitchCameraModeSubscribe()
		{
			Observable.FromEvent<InputAction.CallbackContext>(
					h => _actions.Camera.OverviewLevel.performed += h,
					h => _actions.Camera.OverviewLevel.performed -= h)
				.Subscribe(_ => _switchCameraModePerformed.OnNext(Unit.Default))
				.AddTo(_disposables);
		}
	}
}