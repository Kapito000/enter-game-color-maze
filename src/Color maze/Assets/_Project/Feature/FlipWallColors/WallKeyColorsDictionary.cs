using System;
using CapLib.Collection;
using Feature.FlipWall;
using UnityEngine;

namespace Feature.FlipWallColors
{
	[Serializable]
	public sealed class WallKeyColorsDictionary : SerializedDictionary<WallKey, Color>
	{ }
}