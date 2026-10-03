using Feature.CameraModule.AssetProvider;
using Feature.CameraModule.Factory;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;
using Unity.Cinemachine;

namespace Feature.CameraModule
{
	public sealed class CameraModuleInstaller : MonoInstaller
	{
		[SerializeField] CameraAssetProvider _cameraAssetProvider;
		[SerializeField] CinemachineCamera _levelCamera;

		public override void InstallBindings()
		{
			BindCameraFactory();
			BindCameraProvider();
			BindSpawnCameraSystem();
			BindLevelCameraProvider();
			BindCameraAssetProvider();
		}

		void BindCameraProvider()
		{
			Container
				.Bind<ICameraProvider>()
				.To<CameraProvider>()
				.AsSingle();
		}

		void BindSpawnCameraSystem()
		{
			Container
				.Bind<ISpawnCameraSystem>()
				.To<SpawnCameraSystem>()
				.AsSingle();
		}

		void BindCameraAssetProvider()
		{
			Assert.IsNotNull(_cameraAssetProvider);
			Container.Bind<ICameraAssetProvider>().FromInstance(_cameraAssetProvider)
				.AsSingle();
		}

		void BindCameraFactory()
		{
			Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
		}

		private void BindLevelCameraProvider()
		{
			Container.Bind<ILevelCameraProvider>().FromInstance(new LevelCameraProvider(_levelCamera)).AsSingle();
		}
	}
}

