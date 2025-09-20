using UnityEngine;

namespace Feature.HeroSpawn
{
	public interface IHeroSpawnPoint
	{
		Vector3 Pos();
		Quaternion Rot();
	}
}