using Feature.CameraModule.Factory;
using UnityEngine;
using Zenject;

namespace Feature.CameraModule
{
	public sealed class SpawnCameraSystem : ISpawnCameraSystem
	{
		[Inject] ICameraFactory _cameraFactory;
		[Inject] ICameraProvider _cameraProvider;

		public void Spawn(Transform hero)
		{
			var camera = _cameraFactory.CreateCamera();

			_cameraProvider.Camera = camera;
		}
	}
}