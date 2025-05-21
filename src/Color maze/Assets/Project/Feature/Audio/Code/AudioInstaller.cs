using Feature.Audio.AssetProvider;
using UnityEngine;
using Zenject;

namespace Feature.Audio
{
	public sealed class AudioInstaller : MonoInstaller
	{
		[SerializeField] AudioClipLibrary _clipLibrary;

		public override void InstallBindings()
		{
			BindAudioClipLibrary();
		}

		void BindAudioClipLibrary()
		{
			Container
				.Bind<IAudioClipLibrary<AudioClipType>>()
				.FromInstance(_clipLibrary)
				.AsSingle();
		}
	}
}