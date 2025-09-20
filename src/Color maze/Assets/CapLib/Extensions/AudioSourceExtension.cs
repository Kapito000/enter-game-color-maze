using UnityEngine;

namespace CapLib.Extensions
{
	public static class AudioSourceExtension
	{
		public static AudioSource PlayIfNotPlaying(this AudioSource audioSource)
		{
			if (audioSource.isPlaying)
				return audioSource;

			audioSource.Play();
			return audioSource;
		}
	}
}