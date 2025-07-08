using System;
using Game.Input;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Feature.MovementInput
{
	public sealed class MovementInput : IMovementInput, IDisposable
	{
		CompositeDisposable _disposables = new();

		readonly InputActions _actions;

		public Vector2 NormVelocity { get; private set; }

		public MovementInput(InputActions actions)
		{
			_actions = actions;
			MovementVelocityPerformedSubscribe();
		}

		public void Enable()
		{
			_actions.Movement.Enable();
		}

		public void Disable()
		{
			_actions.Movement.Disable();
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}

		void MovementVelocityPerformedSubscribe()
		{
			Observable
				.FromEvent<InputAction.CallbackContext>(
					h => _actions.Movement.Velocity.performed += h,
					h => _actions.Movement.Velocity.performed -= h)
				.Subscribe(context => NormVelocity = context.ReadValue<Vector2>())
				.AddTo(_disposables);
		}
	}
}