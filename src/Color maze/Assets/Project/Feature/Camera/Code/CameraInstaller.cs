using Feature.Camera.AssetProvider;
using Feature.Camera.Factory;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.Camera
{
	public sealed class CameraInstaller : MonoInstaller
	{
		[SerializeField] CameraProvider _cameraProvider;

		public override void InstallBindings()
		{
			BindCameraFactory();
			BindCameraProvider();
			BindSpawnCameraSystem();
		}

		void BindSpawnCameraSystem()
		{
			Container
				.Bind<ISpawnCameraSystem>()
				.To<SpawnCameraSystem>()
				.AsSingle();
		}

		void BindCameraProvider()
		{
			Assert.IsNotNull(_cameraProvider);
			Container.Bind<ICameraProvider>().FromInstance(_cameraProvider)
				.AsSingle();
		}

		void BindCameraFactory()
		{
			Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
		}
	}
}