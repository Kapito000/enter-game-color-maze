using UnityEngine;
using UnityEngine.Audio;
using Menu = Constant.CreateAssetMenu;

namespace Feature.Audio.Code.MixerGroupProvider
{
	[CreateAssetMenu(menuName = Menu.StaticData + nameof(AudioMixerProvider))]
	public sealed class AudioMixerProvider : ScriptableObject,
		IAudioMixerProvider
	{
		[field: SerializeField] public AudioMixer Mixer { get; private set; }
	}
}