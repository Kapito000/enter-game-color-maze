using Game.Input;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.Humanoid
{
	[RequireComponent(typeof(IHumanoidMovement))]
	public sealed class HumanoidMovementController : MonoBehaviour,
		IHumanoidMovementController
	{
		[Inject] IMovementInput _input;

		IHumanoidMovement _movement;

		[Inject]
		void Construct(IMovementInput input)
		{
			_input = input;
		}

		void Awake()
		{
			_movement = GetComponent<IHumanoidMovement>();
			Assert.IsNotNull(_movement);
		}

		void Update()
		{
			var inputVelocity = _input.NormVelocity;
			_movement.Move(inputVelocity);
		}
	}
}