using Zenject;

namespace Feature.UI
{
	public sealed class UiFactory : IUiFactory
	{
		[Inject] IInstantiator _instantiator;
		[Inject] IUiAssetProvider _assetProvider;

		public void Create()
		{
			var prefab = _assetProvider.UI;
			_instantiator.InstantiatePrefab(prefab);
		}
	}
}