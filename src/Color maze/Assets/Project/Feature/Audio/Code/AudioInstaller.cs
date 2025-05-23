using Feature.Audio.Code.AssetProvider;
using UnityEngine;
using Zenject;

namespace Feature.Audio.Code
{
	public sealed class AudioInstaller : MonoInstaller
	{
		[SerializeField] AudioClipLibrary _clipLibrary;

		public override void InstallBindings()
		{
			BindAudioProviderService();
			BindAudioClipLibrary();
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