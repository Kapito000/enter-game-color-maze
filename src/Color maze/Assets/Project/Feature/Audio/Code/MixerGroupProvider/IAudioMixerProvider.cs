using CapLib.Common;
using UnityEngine.Audio;

namespace Feature.Audio.Code.MixerGroupProvider
{
	public interface IAudioMixerProvider : IService
	{
		AudioMixer Mixer { get; }
	}
}