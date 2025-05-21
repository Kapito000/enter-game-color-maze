using CapLib.Common;
using UnityEngine;

namespace Feature.Audio.Code.AssetProvider
{
	public interface IAudioProviderService : IService
	{
		bool TryGetClip(AudioClipType key, out AudioClip clip);
	}
}