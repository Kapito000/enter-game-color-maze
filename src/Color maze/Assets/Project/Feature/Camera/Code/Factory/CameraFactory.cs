using Feature.Camera.AssetProvider;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Feature.Camera.Factory
{
	public class CameraFactory : ICameraFactory
	{
		[Inject] IInstantiator _instantiator;
		[Inject] ICameraProvider _cameraProvider;

		public CinemachineCamera Create(Transform target)
		{
			SpawnCamera();
			var cmCamera = SpawnCinemachineCamera();
			cmCamera.Follow = target;
			cmCamera.LookAt = target;
			return cmCamera;
		}

		void SpawnCamera()
		{
			var prefab = _cameraProvider.Camera();
			var instance = _instantiator
				.InstantiatePrefabForComponent<UnityEngine.Camera>(prefab);
		}

		CinemachineCamera SpawnCinemachineCamera()
		{
			var prefab = _cameraProvider.CinemachineCamera();
			return _instantiator
				.InstantiatePrefabForComponent<CinemachineCamera>(prefab);
		}
	}
}