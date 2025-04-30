using UnityEngine;

namespace Feature.PlayerHero
{
	[RequireComponent(typeof(Animator))]
	public sealed class HeroAnimator : MonoBehaviour
	{
		Animator _animator;

		readonly int _speed = Animator.StringToHash("Speed");
		readonly int _motionSpeed = Animator.StringToHash("MotionSpeed");

		void Awake()
		{
			_animator = GetComponent<Animator>();
		}
	}
}