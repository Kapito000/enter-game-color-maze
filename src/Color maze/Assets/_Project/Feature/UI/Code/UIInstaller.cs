using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.UI
{
	public sealed class UIInstaller : MonoInstaller
	{
		[SerializeField] UiAssetProvider _uiAssetProvider;

		public override void InstallBindings()
		{
			BindUiFactory();
			BindUiAssetProvider();
		}

		void BindUiFactory()
		{
			Container
				.Bind<IUiFactory>()
				.To<UiFactory>()
				.AsSingle();
		}

		void BindUiAssetProvider()
		{
			Assert.IsNotNull(_uiAssetProvider);
			Container
				.Bind<IUiAssetProvider>()
				.FromInstance(_uiAssetProvider)
				.AsSingle();
		}
	}
}