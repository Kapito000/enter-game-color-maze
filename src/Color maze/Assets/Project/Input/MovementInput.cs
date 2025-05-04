using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
	public sealed class MovementInput : IMovementInput
	{
		readonly Actions _actions;

		public Vector2 NormVelocity { get; private set; }

		public MovementInput(Actions actions)
		{
			_actions = actions;
			_actions.Movement.Velocity.performed += OnMovementDirectionPerformed;
		}

		public void Enable()
		{
			_actions.Movement.Enable();
		}

		public void Disable()
		{
			_actions.Movement.Disable();
		}

		void OnMovementDirectionPerformed(InputAction.CallbackContext context) =>
			NormVelocity = context.ReadValue<Vector2>();
	}
}