using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
	public sealed class MovementInput : IMovementInput
	{
		readonly Actions _actions;

		public Vector2 Direction { get; private set; }

		public MovementInput(Actions actions)
		{
			_actions = actions;
			_actions.Movement.Direcion.performed += OnMovementDirectionPerformed;
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
			Direction = context.ReadValue<Vector2>();
	}
}