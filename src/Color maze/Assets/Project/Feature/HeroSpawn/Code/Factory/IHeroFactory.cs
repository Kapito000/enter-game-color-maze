using CapLib.Common;
using UnityEngine;

namespace Feature.HeroSpawn.Factory
{
	public interface IHeroFactory : IFactory
	{
		GameObject Create(Vector3 pos, Quaternion rot);
	}
}