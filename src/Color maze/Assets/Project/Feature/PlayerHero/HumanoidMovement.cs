using UnityEngine;
using Random = UnityEngine.Random;

namespace Feature.PlayerHero
{
	[RequireComponent(typeof(CharacterController))]
	public class HumanoidMovement : MonoBehaviour, IHumanoidMovement
	{
		[SerializeField] float _speed;
		[SerializeField] float _accelerationRate;

		[Tooltip("How fast the character turns to face movement direction")]
		[Range(0.0f, 0.3f)]
		[SerializeField]
		float _rotationSmoothTime = 0.12f;

		[Tooltip("Acceleration and deceleration")]
		public float SpeedChangeRate = 10.0f;

		public AudioClip LandingAudioClip;
		public AudioClip[] FootstepAudioClips;
		[Range(0, 1)] public float FootstepAudioVolume = 0.5f;

		[Header("Player Grounded")]
		[Tooltip(
			"If the character is grounded or not. " +
			"Not part of the CharacterController built in grounded check")]
		public bool Grounded = true;

		[Tooltip("Useful for rough ground")] public float GroundedOffset = -0.14f;

		[Tooltip(
			"The radius of the grounded check. " +
			"Should match the radius of the CharacterController")]
		public float GroundedRadius = 0.28f;

		float _rotationVelocity;
		float _verticalVelocity;

		float _jumpTimeoutDelta;
		float _fallTimeoutDelta;
		float _targetRotation;

		CharacterController _controller;

		void Awake()
		{
			_controller = GetComponent<CharacterController>();
		}

		public void Move(Vector2 normVelocity)
		{
			float sqrHorizontalNormSpeed = SqrHorizontalNormSpeed();

			float resultSpeed = 0;

			_controller.
			
			var targetSpeed = _speed * sqrHorizontalNormSpeed;
			resultSpeed = Mathf.Lerp(sqrHorizontalNormSpeed, targetSpeed,
				Time.deltaTime * _accelerationRate);

			if (normVelocity != Vector2.zero)
			{
				var targetRot = Mathf
					.Atan2(normVelocity.x, normVelocity.y) * Mathf.Rad2Deg;

				_targetRotation = Mathf.SmoothDampAngle(transform.eulerAngles.y,
					targetRot, ref _rotationVelocity, _rotationSmoothTime);

				transform.rotation = Quaternion.Euler(0.0f, _targetRotation, 0.0f);
			}

			Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) *
			                          Vector3.forward;

			var horizontal = targetDirection.normalized * (_speed * Time.deltaTime);

			var verticalVelocity = new Vector3(0.0f, _verticalVelocity, 0.0f);
			var vertical = verticalVelocity * Time.deltaTime;

			_controller.Move(horizontal + vertical);
		}

		float SqrHorizontalNormSpeed() =>
			new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z)
				.sqrMagnitude;

		void OnDrawGizmosSelected()
		{
			Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
			Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

			if (Grounded) Gizmos.color = transparentGreen;
			else Gizmos.color = transparentRed;

			// when selected, draw a gizmo in the position of,
			// and matching radius of, the grounded collider
			Gizmos.DrawSphere(
				new Vector3(transform.position.x, transform.position.y - GroundedOffset,
					transform.position.z),
				GroundedRadius);
		}

		void OnFootstep(AnimationEvent animationEvent)
		{
			if (animationEvent.animatorClipInfo.weight > 0.5f)
			{
				if (FootstepAudioClips.Length > 0)
				{
					var index = Random.Range(0, FootstepAudioClips.Length);
					AudioSource.PlayClipAtPoint(FootstepAudioClips[index],
						transform.TransformPoint(_controller.center), FootstepAudioVolume);
				}
			}
		}

		void OnLand(AnimationEvent animationEvent)
		{
			if (animationEvent.animatorClipInfo.weight > 0.5f)
			{
				AudioSource.PlayClipAtPoint(LandingAudioClip,
					transform.TransformPoint(_controller.center), FootstepAudioVolume);
			}
		}
	}
}