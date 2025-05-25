using UniRx;
using UnityEngine;

namespace Feature.Humanoid
{
	public interface IHumanoidMovement
	{
		void Move(Vector2 velocity);
		IReadOnlyReactiveProperty<float> CurrentSpeed { get; }
		float MaxSpeed { get; }
	}
}