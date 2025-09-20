using Feature.Audio.Code.AssetProvider;
using Feature.Audio.Code.MixerGroupProvider;
using UnityEngine;
using Zenject;

namespace Feature.Audio.Code
{
	public sealed class AudioInstaller : MonoInstaller
	{
		[SerializeField] AudioClipLibrary _clipLibrary;
		[SerializeField] AudioMixerProvider _audioMixerProvider;

		public override void InstallBindings()
		{
			BindAudioClipLibrary();
			BindAudioMixerProvider();
			BindAudioProviderService();
		}

		void BindAudioMixerProvider()
		{
			Container
				.Bind<IAudioMixerProvider>()
				.FromInstance(_audioMixerProvider)
				.AsSingle();
		}

		void BindAudioProviderService()
		{
			Container
				.Bind<IAudioProvider>()
				.To<AudioProvider>()
				.AsSingle();
		}

		void BindAudioClipLibrary()
		{
			Container
				.Bind<IAudioClipLibrary<AudioClipType>>()
				.FromInstance(_clipLibrary)
				.AsSingle()
				.WhenInjectedInto<IAudioProvider>();
		}
	}
}