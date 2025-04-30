using Game.Input;
using UnityEngine;
using Zenject;

namespace Feature.PlayerHero
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
		}

		void Update()
		{
			var direction = _input.Direction;
			_movement.Move(direction);
		}
	}
}