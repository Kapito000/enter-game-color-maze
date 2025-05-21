using Feature.Audio.Code;
using Feature.Audio.Code.AssetProvider;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.Humanoid
{
	[RequireComponent(typeof(Animator))]
	public sealed class HumanoidFootStepAudio : MonoBehaviour
	{
		[SerializeField] AudioSource _stepAudioSource;

		[Inject] IHumanoidMovement _movement;
		[Inject] IAudioProviderService _audioProviderService;

		void Awake()
		{
			Assert.IsNotNull(_stepAudioSource);

			if (_audioProviderService.TryGetClip(AudioClipType.HumanoidStep,
				    out var clip) == false)
				return;

			Init(clip);
		}

		void SetFootStepSound(AudioClip footStepSound)
		{
			_stepAudioSource.clip = footStepSound;
		}

		void Init(AudioClip footStepSound)
		{
			_stepAudioSource.loop = false;
			SetFootStepSound(footStepSound);
		}

		void OnFootstep() // Animation event.
		{
			if (Mathf.Approximately(_movement.CurrentSpeed.Value, 0) ||
			    _stepAudioSource.isPlaying)
				return;

			_stepAudioSource.Play();
		}
	}
}