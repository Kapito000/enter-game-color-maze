using CapLib.Common;
using UnityEngine;

namespace Feature.Audio.Code.AssetProvider
{
	public interface IAudioProvider : IService
	{
		bool TryGetClip(AudioClipType key, out AudioClip clip);
	}
}