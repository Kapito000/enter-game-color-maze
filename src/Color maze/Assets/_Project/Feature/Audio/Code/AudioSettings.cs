using CapLib.AudioMixerUtility;
using Feature.Audio.Code.MixerGroupProvider;
using UnityEngine;
using Zenject;

namespace Feature.Audio.Code
{
	public sealed class AudioSettings : IAudioSettings
	{
		[Inject] IAudioMixerProvider _mixerProvider;

		public bool SetVolume(MixerGroup group, float value)
		{
			if (TryGetVolumeParameter(group, out var mixerParameter) == false)
				return false;

			SetMixerVolume(value, mixerParameter);
			return true;
		}

		public bool TryGetVolumeValue(MixerGroup mixerGroup, out float value)
		{
			if (TryGetVolumeParameter(mixerGroup, out var parameter) == false ||
			    TryGetMixerValue(parameter, out var volume) == false)
			{
				value = default;
				return false;
			}

			var maxVolume = Constant.AudioMixerValue.MaxVolume;
			var minVolume = Constant.AudioMixerValue.MinVolume;
			value = VolumeConverter.ConvertToValue(volume, minVolume, maxVolume);
			return true;
		}

		void SetMixerVolume(float value, string parameter)
		{
			var maxVolume = Constant.AudioMixerValue.MaxVolume;
			var minVolume = Constant.AudioMixerValue.MinVolume;
			var volume = VolumeConverter
				.ConvertToMixerVolume(value, minVolume, maxVolume);
			TrySetMixerValue(parameter, volume);
		}

		bool TryGetMixerValue(string parameter, out float value)
		{
			if (_mixerProvider.Mixer.GetFloat(parameter, out value))
				return true;

			Debug.LogError(
				$"Cannot to get mixer volume by the \"{parameter}\" parameter.");
			return false;
		}

		bool TrySetMixerValue(string parameter, float value)
		{
			if (_mixerProvider.Mixer.SetFloat(parameter, value))
				return true;

			Debug.LogError(
				$"Cannot to set mixer volume by the \"{parameter}\" parameter.");
			return false;
		}

		bool TryGetVolumeParameter(MixerGroup mixerGroup, out string parameter)
		{
			switch (mixerGroup)
			{
				case MixerGroup.Master:
					parameter = Constant.AudioMixerParameter.MainVolume;
					break;
				case MixerGroup.SFX:
					parameter = Constant.AudioMixerParameter.SfxVolume;
					break;
				case MixerGroup.Ambient:
					parameter = Constant.AudioMixerParameter.AmbientVolume;
					break;
				default:
					Debug.LogError($"Unknown {nameof(mixerGroup)}: \"{mixerGroup}\".");
					parameter = default;
					return false;
			}

			return true;
		}
	}
}