using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Feature.CameraModule
{
	public sealed class OverviewLevelInstaller : MonoInstaller
	{
		[SerializeField] CinemachineCamera _overviewLevelCamera;

		public override void InstallBindings()
		{
			BindOverviewLevelCamera();
		}

		void BindOverviewLevelCamera()
		{
			Assert.IsNotNull(_overviewLevelCamera);
			Container
				.Bind<CinemachineVirtualCameraBase>()
				.WithId(VirtualCameraMode.LevelOverview)
				.FromInstance(_overviewLevelCamera)
				.AsSingle()
				;
		}
	}
}