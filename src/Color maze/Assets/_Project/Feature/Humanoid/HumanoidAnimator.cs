using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Humanoid
{
	[RequireComponent(typeof(Animator))]
	public sealed class HumanoidAnimator : MonoBehaviour
	{
		[Range(0, 1)]
		[SerializeField] float _idleSpeed = .1f;

		Animator _animator;
		IHumanoidMovement _movement;

		readonly int _speedHash = Animator.StringToHash("Speed");

		void Awake()
		{
			_animator = GetComponent<Animator>();
			_movement = GetComponent<IHumanoidMovement>();
			Assert.IsNotNull(_animator);
			Assert.IsNotNull(_movement);

			_movement.CurrentSpeed.Subscribe(OnSpeedChanged).AddTo(this);
		}

		void OnSpeedChanged(float speedValue)
		{
			var value = speedValue / _movement.MaxSpeed;
			if (speedValue < _idleSpeed)
				value = 0;

			_animator.SetFloat(_speedHash, value);
		}
	}
}