using UnityEngine;
using Zenject;

namespace Feature.Audio.Code.AssetProvider
{
	public sealed class AudioProviderService : IAudioProviderService
	{
		[Inject] IAudioClipLibrary<AudioClipType> _library;

		public bool TryGetClip(AudioClipType key, out AudioClip clip)
		{
			var result = _library.TryGetClip(key, out clip);

			if (result == false)
				Debug.LogError($"Cannot to get audio clip by key: {key}");

			return result;
		}
	}
}