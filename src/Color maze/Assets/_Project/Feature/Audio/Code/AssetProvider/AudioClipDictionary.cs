using System;
using CapLib.Collection;
using UnityEngine;

namespace Feature.Audio.Code.AssetProvider
{
	[Serializable]
	public sealed class
		AudioClipDictionary : SerializedDictionary<AudioClipType, AudioClip>
	{ }
}