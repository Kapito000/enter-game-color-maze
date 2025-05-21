using CapLib.Common;
using UnityEngine;

namespace Feature.Audio.Code.AssetProvider
{
	public interface IAudioClipLibrary<in TKey> : IAssetProvider
	{
		bool TryGetClip(TKey key, out AudioClip clip);
	}
}