using UnityEngine;

namespace Feature.HeroSpawn
{
	public class HeroSpawnPoint : MonoBehaviour, IHeroSpawnPoint
	{
		public Vector3 Pos() => transform.position;

		public Quaternion Rot() => transform.rotation;
	}
}