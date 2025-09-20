using UnityEngine;
using Menu = Constant.CreateAssetMenu;

namespace Feature.Audio.Code.AssetProvider
{
	[CreateAssetMenu(menuName = Menu.StaticData + nameof(AudioClipLibrary))]
	public sealed class AudioClipLibrary : ScriptableObject,
		IAudioClipLibrary<AudioClipType>
	{
		[SerializeField] AudioClipDictionary _clips;

		public bool TryGetClip(AudioClipType key, out AudioClip clip) =>
			_clips.TryGetValue(key, out clip);
	}
}