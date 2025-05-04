using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Feature.PlayerHero
{
	[RequireComponent(typeof(CharacterController))]
	public class HumanoidMovement : MonoBehaviour, IHumanoidMovement
	{
		[SerializeField] float _speed = 3f;

		[SerializeField] float _acceleration = 10f;
		[SerializeField] float _rotationSpeed = 15f;

		float _currentSpeed;
		Vector3 _currentVelocity;
		CharacterController _characterController;

		void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			Assert.IsNotNull(_characterController);
		}

		void Update()
		{
			ApplyGravity();
			MoveCharacter();
		}

		public void Move(Vector2 velocity)
		{
			velocity = NormalizeVelocity(velocity);

			float targetSpeed = Mathf.Lerp(0f, _speed, velocity.magnitude);
			_currentSpeed = Mathf.Lerp(_currentSpeed, targetSpeed,
				_acceleration * Time.deltaTime);

			Vector3 moveDirection = new Vector3(velocity.x, 0, velocity.y).normalized;

			Vector3 horizontalVelocity = moveDirection * _currentSpeed;
			_currentVelocity.x = horizontalVelocity.x;
			_currentVelocity.z = horizontalVelocity.z;

			if (moveDirection != Vector3.zero)
			{
				Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
				transform.rotation = Quaternion.Slerp(
					transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
			}
		}

		void ApplyGravity()
		{
			if (_characterController.isGrounded)
				_currentVelocity.y = -0.5f;
			else
				_currentVelocity.y += Physics.gravity.y * Time.deltaTime;
		}

		void MoveCharacter()
		{
			_characterController.Move(_currentVelocity * Time.deltaTime);
		}

		Vector2 NormalizeVelocity(Vector2 velocity) =>
			velocity.sqrMagnitude > 1f
				? velocity.normalized
				: velocity;
	}
}