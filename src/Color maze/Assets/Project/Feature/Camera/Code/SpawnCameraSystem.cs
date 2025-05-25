using Feature.Camera.Factory;
using UnityEngine;
using Zenject;

namespace Feature.Camera
{
	public sealed class SpawnCameraSystem : ISpawnCameraSystem
	{
		[Inject] ICameraFactory _cameraFactory;

		public void Spawn(Transform hero)
		{
			_cameraFactory.Create(hero);
		}
	}
}