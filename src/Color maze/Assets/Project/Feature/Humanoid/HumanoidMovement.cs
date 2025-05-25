using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Humanoid
{
	[RequireComponent(typeof(CharacterController))]
	public class HumanoidMovement : MonoBehaviour, IHumanoidMovement
	{
		[SerializeField] float _maxSpeed = 3f;
		[SerializeField] float _acceleration = 10f;
		[SerializeField] float _rotationSpeed = 15f;
		[ReadOnly]
		[SerializeField] ReactiveProperty<float> _currentSpeed;

		Vector3 _currentVelocity;
		CharacterController _characterController;

		public float MaxSpeed => _maxSpeed;
		public IReadOnlyReactiveProperty<float> CurrentSpeed => _currentSpeed;

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
			velocity = NormalizeLimit(velocity);
			CalculateCurrentSpeed(velocity);
			Vector3 moveDirection = MoveDirection(velocity);
			CalculateCurrentVelocity(moveDirection);
			Rotate(moveDirection);
		}

		void Rotate(Vector3 moveDirection)
		{
			if (moveDirection == Vector3.zero)
				return;

			Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
			transform.rotation = Quaternion.Slerp(
				transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
		}

		static Vector3 MoveDirection(Vector2 velocity)
		{
			return new Vector3(velocity.x, 0, velocity.y).normalized;
		}

		void CalculateCurrentVelocity(Vector3 moveDirection)
		{
			Vector3 horizontalVelocity = moveDirection * _currentSpeed.Value;
			_currentVelocity.x = horizontalVelocity.x;
			_currentVelocity.z = horizontalVelocity.z;
		}

		void CalculateCurrentSpeed(Vector2 velocity)
		{
			var velocityMagnitude = velocity.magnitude;
			float targetSpeed = Mathf.Lerp(0f, MaxSpeed, velocityMagnitude);
			_currentSpeed.Value = Mathf.Lerp(_currentSpeed.Value, targetSpeed,
				_acceleration * Time.deltaTime);
		}

		void ApplyGravity()
		{
			if (_characterController.isGrounded)
				_currentVelocity.y = -0.5f;
			else
				_currentVelocity.y += UnityEngine.Physics.gravity.y * Time.deltaTime;
		}

		void MoveCharacter()
		{
			_characterController.Move(_currentVelocity * Time.deltaTime);
		}

		Vector2 NormalizeLimit(Vector2 velocity) =>
			velocity.sqrMagnitude > 1f
				? velocity.normalized
				: velocity;
	}
}