using System;
using Game.Input;
using UniRx;
using UnityEngine.InputSystem;

namespace Feature.ServicesInput
{
	public sealed class ServicesInput : IServicesInput, IDisposable
	{
		readonly InputActions _actions;
		readonly CompositeDisposable _disposables = new();

		readonly Subject<Unit> _quitePerformed = new();
		readonly Subject<Unit> _restartPerformed = new();

		public IObservable<Unit> QuitePerformed => _quitePerformed;
		public IObservable<Unit> RestartPerformed => _restartPerformed;

		public ServicesInput(InputActions actions)
		{
			_actions = actions;

			Observable.FromEvent<InputAction.CallbackContext>(
					h => _actions.Services.Restart.performed += h,
					h => _actions.Services.Restart.performed -= h)
				.Subscribe(_ => _restartPerformed.OnNext(Unit.Default))
				.AddTo(_disposables);

			Observable.FromEvent<InputAction.CallbackContext>(
					h => _actions.Services.Quite.performed += h,
					h => _actions.Services.Restart.performed -= h)
				.Subscribe(_ => _quitePerformed.OnNext(Unit.Default))
				.AddTo(_disposables);
		}

		public void Enable()
		{
			_actions.Services.Enable();
		}

		public void Disable()
		{
			_actions.Services.Disable();
		}

		public void Dispose()
		{
			_disposables.Dispose();
			_restartPerformed.OnCompleted();
			_restartPerformed.Dispose();
		}
	}
}