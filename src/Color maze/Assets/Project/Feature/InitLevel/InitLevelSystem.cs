using Feature.CameraModule;
using Feature.HeroSpawn;
using UnityEngine;
using Zenject;

namespace Feature.InitLevel
{
	public class InitLevelSystem : MonoBehaviour
	{
		[Inject] IHeroSpawnSystem _heroSpawnSystem;
		[Inject] ISpawnCameraSystem  _spawnCameraSystem;
		
		void Start()
		{
			if (_heroSpawnSystem.TrySpawn(out var heroObj) == false)
			{
				Debug.LogError("Failed to spawn hero.");
				return;
			}
			
			_spawnCameraSystem.Spawn(heroObj.transform);
		}
	}
}