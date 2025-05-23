using CapLib.Extensions;
using Feature.Audio.Code;
using Feature.Audio.Code.AssetProvider;
using UniRx;
using UnityEngine;
using Zenject;

namespace Feature.FlipWall
{
	public sealed class FlipWallAudio : MonoBehaviour
	{
		[SerializeField] AudioSource _audioSource;

		[Inject] IAudioProvider _audioProvider;
		[Inject] IFlipWallSystem _flipWallSystem;

		void Awake()
		{
			if (_audioProvider
				    .TryGetClip(AudioClipType.FlipWall, out var clip) == false)
			{
				Debug.LogError("No clip found for flip wall.");
				return;
			}

			_audioSource.clip = clip;

			_flipWallSystem
				.WallTurned
				.Subscribe(_ => _audioSource.PlayIfNotPlaying())
				.AddTo(this);
		}
	}
}