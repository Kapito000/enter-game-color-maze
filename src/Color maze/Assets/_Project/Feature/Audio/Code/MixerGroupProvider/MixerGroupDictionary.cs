using System;
using CapLib.Collection;
using UnityEngine.Audio;

namespace Feature.Audio.Code.MixerGroupProvider
{
	[Serializable]
	public sealed class MixerGroupDictionary
		: SerializedDictionary<MixerGroup, AudioMixerGroup>
	{ }
}