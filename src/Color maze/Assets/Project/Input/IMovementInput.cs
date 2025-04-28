using UnityEngine;

namespace Game.Input
{
	public interface IMovementInput : IInputService
	{
		Vector2 Direction { get; }
	}
}