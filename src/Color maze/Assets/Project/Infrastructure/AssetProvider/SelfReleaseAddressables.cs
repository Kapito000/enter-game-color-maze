using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Infrastructure.AssetProvider
{
	public sealed class SelfReleaseAddressables : MonoBehaviour
	{
		void OnDestroy()
		{
			if (Addressables.ReleaseInstance(gameObject) == false)
				Destroy(gameObject);
		}
	}
}