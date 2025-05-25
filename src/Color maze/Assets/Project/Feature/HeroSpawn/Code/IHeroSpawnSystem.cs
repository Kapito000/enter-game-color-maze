using UnityEngine;

namespace Feature.HeroSpawn
{
	public interface IHeroSpawnSystem
	{
		bool TrySpawn(out GameObject hero);
	}
}