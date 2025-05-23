using Feature.Audio.Code.AssetProvider;
using UnityEngine;
using Zenject;

namespace Feature.Audio.Code
{
	public sealed class AmbientSound : MonoBehaviour
	{
		[SerializeField] AudioSource _audioSource;

		[Inject] IAudioProvider _audioProvider;

		void Awake()
		{
			if (_audioProvider.TryGetClip(AudioClipType.AmbientSound,
				    out AudioClip clip) == false)
			{
				Debug.LogError("Cannot find ambient sound clip.");
				enabled = false;
				return;
			}

			Tune(clip);
		}

		void Start()
		{
			if (_audioSource.isPlaying == false)
				_audioSource.Play();
		}

		void Tune(AudioClip clip)
		{
			_audioSource.clip = clip;
			_audioSource.loop = true;
			_audioSource.spatialBlend = 0f;
		}
	}
}