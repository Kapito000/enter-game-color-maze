namespace Feature.Audio.Code
{
	public interface IAudioSettings
	{
		bool SetVolume(MixerGroup group, float value);
		bool TryGetVolumeValue(MixerGroup group, out float value);
	}
}