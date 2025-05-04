using UnityEngine;

namespace Game.Input
{
	public interface IMovementInput : IInputService
	{
		Vector2 NormVelocity { get; }
	}
}