using Feature.CameraModule.AssetProvider;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Feature.CameraModule.Factory
{
	public class CameraFactory : ICameraFactory
	{
		[Inject] IInstantiator _instantiator;
		[Inject] ICameraAssetProvider _cameraAssetProvider;

		public CinemachineCamera CreateVirtualCamera(Transform target)
		{
			var cmCamera = SpawnCinemachineCamera();
			// cmCamera.Follow = target;
			// cmCamera.LookAt = target;
			return cmCamera;
		}

		public Camera CreateCamera()
		{
			var prefab = _cameraAssetProvider.Camera();
			return _instantiator.InstantiatePrefabForComponent<Camera>(prefab);
		}

		CinemachineCamera SpawnCinemachineCamera()
		{
			var prefab = _cameraAssetProvider.CinemachineCamera();
			return _instantiator
				.InstantiatePrefabForComponent<CinemachineCamera>(prefab);
		}
	}
}