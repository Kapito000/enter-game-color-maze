using UnityEngine;

namespace CapLib.AudioMixerUtility
{
	public static class VolumeConverter
	{
		public static float ConvertToMixerVolume(float value,
			float minVolume, float maxVolume)
		{
			return Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f))
				* (maxVolume - minVolume) / 4f + maxVolume;
		}

		public static float ConvertToValue(float volume,
			float minVolume, float maxVolume)
		{
			return Mathf.Pow(10, 4 * (volume - maxVolume) / (maxVolume - minVolume));
		}
	}
}