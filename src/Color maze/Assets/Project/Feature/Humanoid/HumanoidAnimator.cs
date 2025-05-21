using UniRx;
using UnityEngine;
using UnityEngine.Assertions;

namespace Feature.Humanoid
{
	[RequireComponent(typeof(Animator))]
	public sealed class HumanoidAnimator : MonoBehaviour
	{
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
			_animator.SetFloat(_speedHash, speedValue);
		}
	}
}