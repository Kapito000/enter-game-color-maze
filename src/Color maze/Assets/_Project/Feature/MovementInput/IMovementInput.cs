using Game.Input;
using UnityEngine;

namespace Feature.MovementInput
{
	public interface IMovementInput : IInputService
	{
		Vector2 NormVelocity { get; }
	}
}